const messageType = {
    SUCCESS: 1,
    ERROR: 2,
    WARNING: 3,
    INFO: 4
};

const globalConstants = {
    Sim: 1,
    Nao: 0
};

const baseSystemUrl = $(document).find('base').attr('href');
const messageRemoveSuccess = 'Registro excluído com sucesso!';
const messageTitleAskRemove = 'Exclusão de Registro';
const messageAskRemove = 'Deseja realmente excluir o registro?';

// Do this before you initialize any of your modals
$.fn.modal.Constructor.prototype.enforceFocus = function () { };

$(document).on('show.bs.modal', '.modal', function () {
    var zIndex = 1040 + (10 * $('.modal:visible').length);
    $(this).css('z-index', zIndex);
    setTimeout(function () {
        $('.modal-backdrop').not('.modal-stack').css('z-index', zIndex - 1).addClass('modal-stack');
    }, 0);
});

$('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
    $.fn.dataTable.tables({ visible: true, api: true }).columns.adjust();
});

var onGlobalFailed = function (error) {

    if (error.status === 403) {
        alertify.error(error.responseText);
    } else if (error.status === 401) {
        logoutUser();
    }
    else {
        try {
            var result = JSON.parse(error.responseText);
            alertify.error(result.message);
        } catch (e) {
            var errorResult = e;
        }
    }
};

var onGlobalSuccess = function (result) {
    showMessage(result);
};

var onExcluirRegistroSuccess = function (element, dataTableName) {

    //Mensagem de Sucesso
    var resultMessage = {
        type: messageType.SUCCESS,
        message: messageRemoveSuccess
    };

    showMessage(resultMessage);

    var parentElement = $(element).parents('tr');

    $('#' + dataTableName).DataTable()
        .row(parentElement)
        .remove()
        .draw();
};

var logoutUser = function () {
    window.location = window.location.origin + '/login/LogOutUsuario';
};

var excluirRegistro = function (element, url, dataTableControlName) {

    var dataTableControl;

    if (dataTableControlName) {
        dataTableControl = $("#" + dataTableControlName);
    }

    alertify.confirm('Exclusão de Registro', 'Deseja realmente excluir o registro?',
        function () {
            $.ajax(
                {
                    type: 'GET',
                    url: url,
                    cache: false,
                    success: function (result) {

                        showMessage(result);

                        if (result.type === messageType.SUCCESS) {

                            var parentElement = $(element).parents('tr');

                            dataTableControl.DataTable()
                                .row(parentElement)
                                .remove()
                                .draw();
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {

                        if (XMLHttpRequest.status === 403) {
                            alertify.error(XMLHttpRequest.responseText);
                        }
                        else {
                            var result = JSON.parse(XMLHttpRequest.responseText);
                            alertify.error(result.message);
                        }
                    }
                });
        },
        function () { }).set('labels', { ok: 'Sim', cancel: 'Não' }).set('closable', false);
};

var progressVisible = false;

var showProgress = function () {
    if (!progressVisible) {
        $("div#spinner").fadeIn("fast");
        progressVisible = true;
    }
};

var hideProgress = function () {
    if (progressVisible) {
        var spinner = $("div#spinner");
        spinner.stop();
        spinner.fadeOut("fast");
        progressVisible = false;
    }
};

var showMessage = function (result) {

    if (result.type === messageType.SUCCESS) {
        alertify.success(result.message);
    } else if (result.type === messageType.ERROR) {
        alertify.error(result.message);
    } else if (result.type === messageType.WARNING) {
        alertify.warning(result.message);
    } else if (result.type === messageType.INFO) {
        alertify.message(result.message);
    }
};

var showMessageAlert = function (title, message) {
    alertify.alert(title, message, function () { }).set('closable', false);
};

$(document).bind("ajaxSend", function (event, jqxhr, settings) {
    if (!settings.removeLoading) {
        showProgress();
    }
    //}).bind("ajaxComplete", function () {
    //    hideProgress();
}).bind("ajaxStop", function () {
    hideProgress();
});

var isHTML = function (str) {
    var htmlRegex = new RegExp("<([A-Za-z][A-Za-z0-9]*)\\b[^>]*>(.*?)</\\1>");
    return htmlRegex.test(str);
};

var noSpace = function (event) {
    var k = event ? event.which : window.event.keyCode;
    if (k === 32) return false;
};

var onlyAlphaNumeric = function (event) {
    if (!/[0-9a-zA-Z-]/.test(String.fromCharCode(event.which)))
        return false;
};

var exportXlsx = function (url, params) {
    $.ajax({
        url: url,
        type: 'POST',
        dataType: 'json',
        removeLoading: true,
        data: params,
        success: function (response, status, xhr) {
            window.location = baseSystemUrl + 'download/xlsx/?fileGuid=' + response.fileGuid + '&filename=' + response.fileName;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            onGlobalFailed(XMLHttpRequest);
        }
    });
};

var printTable = function (url, params) {

    var id = (new Date()).getTime();
    var myWindow = window.open(window.location.href + '?printerFriendly=true', id, "toolbar=1,scrollbars=1,location=0,statusbar=0,menubar=1,resizable=1,width=800,height=600,left = 240,top = 212");

    $.ajax({
        url: url,
        type: 'POST',
        dataType: 'json',
        removeLoading: true,
        data: params,
        success: function (response, status, xhr) {

            var table = makeHtmlTable(response.data);

            var htmlToPrint = '' +
                '<style type="text/css">' +
                'table th, table td {' +
                'border:1px solid #000;' +
                'padding;0.5em;' +
                '}' +
                '</style><h1>' + response.fileName + '</h1>';

            htmlToPrint += table[0].outerHTML;

            myWindow.document.write(htmlToPrint);
            myWindow.focus();
            myWindow.print();
            myWindow.close();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            onGlobalFailed(XMLHttpRequest);
            myWindow.close();
        }
    });
};

var makeHtmlTable = function (mydata) {
    var table = $("<table border=1 style='width: 100%'>");
    var tblHeader = "<tr>";
    for (var k in mydata[0]) tblHeader += "<th>" + k.toUpperCase() + "</th>";
    tblHeader += "</tr>";
    $(tblHeader).appendTo(table);
    $.each(mydata, function (index, value) {
        var TableRow = "<tr>";
        $.each(value, function (key, val) {
            TableRow += "<td>" + (val !== null && val !== '' ? val : '') + "</td>";
        });
        TableRow += "</tr>";
        $(table).append(TableRow);
    });
    return ($(table));
};

var formatarValorMonetario = function (valor) {
    var valorFormatado = valor.toLocaleString("pt-BR", { style: "currency", currency: "BRL" });
    return valorFormatado;
};

var formatarValorMonetarioNumero = function (valor) {
    var valorFormatado = parseFloat(valor).toLocaleString('pt-BR', { minimumFractionDigits: 2 });
    return valorFormatado;
};

var toDate = function (dateStr) {

    var date = new Date(dateStr);

    var dd = date.getDate();
    var mm = date.getMonth() + 1; //January is 0!

    var yyyy = date.getFullYear();

    if (dd < 10) {
        dd = '0' + dd;
    }

    if (mm < 10) {
        mm = '0' + mm;
    }

    return (dd + '/' + mm + '/' + yyyy);
};

var GetLocalStorageSize = function () {
    var _lsTotal = 0, _xLen, _x;

    for (_x in localStorage) {
        _xLen = (((localStorage[_x].length || 0) + (_x.length || 0)) * 2);
        _lsTotal += _xLen; console.log(_x.substr(0, 50) + " = " + (_xLen / 1024).toFixed(2) + " KB");
    };

    console.log("Total = " + (_lsTotal / 1024).toFixed(2) + " KB");
};

var GetSessionStorageSize = function () {
    var _lsTotal = 0, _xLen, _x;

    for (_x in sessionStorage) {
        _xLen = (((sessionStorage[_x].length || 0) + (_x.length || 0)) * 2);
        _lsTotal += _xLen; console.log(_x.substr(0, 50) + " = " + (_xLen / 1024).toFixed(2) + " KB");
    };

    console.log("Total = " + (_lsTotal / 1024).toFixed(2) + " KB");
};

var AlertaFecharModal = function (modal) {

    alertify.confirm('Confirmação', 'Existem informações não salvas. Deseja realmente fechar a tela?',
        function () {
            $('#' + modal).modal("hide");
        },
        function () { }).set('labels', { ok: 'Sim', cancel: 'Não' }).set('closable', false);
};

var aplicarMascaraInscricaoEstadual = function (elemento, idUf) {

    var maskForInscricaoRN = function (val) {
        return val.replace(/\D/g, '').length === 10 ? '00.0.000.000-0' : '00.000.000-09';
    }, optionsRN = {
        onKeyPress: function (val, e, field, options) {
            field.mask(maskBehavior.apply({}, arguments), options);
        }
    };

    switch (idUf) {
        case "11":
            //Rondonia                
            $(elemento).mask('0000000000000-0', { reverse: true });
            break;
        case "12":
            //Acre 
            $(elemento).mask('00.000.000/000-00', { reverse: true });
            break;
        case "13":
            //Amazonas
            $(elemento).mask('00.000.000-0', { reverse: true });
            break;
        case "14":
            //Roraima 
            $(elemento).mask('00.000000-0', { reverse: true });
            break;
        case "15":
            //Pará
            $(elemento).mask('00.000.000-0', { reverse: true });
            break;
        case "16":
            //Amapá 
            $(elemento).mask('000000000', { reverse: true }); // NAO CONSEGUIU VALIDAR
            break;
        case "17":
            //Tocantins
            $(elemento).mask('00.000.000-0', { reverse: true });
            break;
        case "21":
            //Maranhão
            $(elemento).mask('000000000', { reverse: true });
            break;
        case "22":
            //Piauí
            $(elemento).mask('000000000', { reverse: true });
            break;
        case "23":
            //Ceará
            $(elemento).mask('00.000000-0', { reverse: true });
            break;
        case "24":
            //Rio Grande do Norte                
            $(elemento).mask(maskForInscricaoRN, optionsRN);
            break;
        case "25":
            //Paraíba  
            $(elemento).mask('00.000.000-0', { reverse: true });
            break;
        case "26":
            //Pernambuco
            $(elemento).mask('0000000-00', { reverse: true });
            break;
        case "27":
            //Alagoas
            $(elemento).mask('00000000-0', { reverse: true });
            break;
        case "28":
            //Sergipe
            $(elemento).mask('00.000.000-0', { reverse: true });
            break;
        case "29":
            //Bahia                
            $(elemento).mask('000.000.000', { reverse: true });
            break;
        case "31":
            //Minas Gerais  
            $(elemento).mask('000000000.00-00', { reverse: true });
            break;
        case "32":
            //Espírito Santo
            $(elemento).mask('000.000.00-0', { reverse: true });
            break;
        case "33":
            //Rio de Janeiro 
            $(elemento).mask('00.000.00-0', { reverse: true });
            break;
        case "35":
            //São Paulo
            $(elemento).mask('000.000.000.000', { reverse: true });
            break;
        case "41":
            //Paraná 
            $(elemento).mask('00000000-00', { reverse: true });
            break;
        case "42":
            //Santa Catarina
            $(elemento).mask('000.000.000', { reverse: true });
            break;
        case "43":
            //Rio Grande do Sul
            $(elemento).mask('000/0000000', { reverse: true });
            break;
        case "50":
            //Mato Grosso do Sul
            $(elemento).mask('000000000', { reverse: true });
            break;
        case "51":
            //Mato Grosso
            $(elemento).mask('0000000000-0', { reverse: true });
            break;
        case "52":
            //Goiás
            $(elemento).mask('00.000.000-0', { reverse: true });
            break;
        case "53":
            //Distrito Federal
            $(elemento).mask('00000000000-00', { reverse: true });
            break;
    }
};

var GetCurrentDate = function () {

    var date = new Date();
    var aaaa = date.getFullYear();
    var gg = date.getDate();
    var mm = (date.getMonth() + 1);

    if (gg < 10)
        gg = "0" + gg;

    if (mm < 10)
        mm = "0" + mm;

    var cur_day = gg + "/" + mm + "/" + aaaa;

    var hours = date.getHours();
    var minutes = date.getMinutes();
    var seconds = date.getSeconds();

    if (hours < 10)
        hours = "0" + hours;

    if (minutes < 10)
        minutes = "0" + minutes;

    if (seconds < 10)
        seconds = "0" + seconds;

    return cur_day + " " + hours + ":" + minutes + ":" + seconds;
};