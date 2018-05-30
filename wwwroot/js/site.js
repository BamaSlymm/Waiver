﻿// Write your Javascript code.

var globalObj = {
    debugOn: true
};

function showIfSelected(selectItemId, divsToHide, opts) {
    writeToConsole(selectItemId + ' : ' + divsToHide + ' : ' + JSON.stringify(opts));
    let myList = [];
    if (opts && opts.textList) {
        myList = opts.textList;
    }
    if (opts && opts.valueList) {
        myList = opts.valueList;
    }

    myList.some(function (toCheck) {
        let matchFound = false ;
        if (opts && opts.textList) {
            matchFound = ( $(selectItemId + ' option:selected').text() === toCheck );
            writeToConsole('matchFound : ' + matchFound + ' : ' + ' val ' + $(selectItemId + ' option:selected').text());
        }
        if (opts && opts.valueList) {
            matchFound = ( $(selectItemId + ' option:selected').val() === toCheck );
            writeToConsole('matchFound : ' + matchFound + ' : ' + ' val ' + $(selectItemId + ' option:selected').val());
        }

        if (opts && opts.hide) {
            if (matchFound) {
                divsToHide.forEach(function(divToHide) {
                    $(divToHide).hide({duration: 560});
                });
                return true;
            } else {
                divsToHide.forEach(function(divToHide) {
                    $(divToHide).show({duration: 200});
                });
                return false;
            }
        }
        if (matchFound) {
            divsToHide.forEach(function(divToHide) {
                $(divToHide).show({duration: 560});
            });
            return true;
        } else {
            divsToHide.forEach(function(divToHide) {
                $(divToHide).hide({duration: 200});
            });
            return false;
        }
    });
}

function showIfNotEmpty(inputItemId, divToHide, opts) {
    writeToConsole(inputItemId + ' : ' + divToHide + ' : ' + JSON.stringify(opts));

    let notEmptyString = false ;
    notEmptyString = ( $(inputItemId).val() );
    if (notEmptyString) {
        $(divToHide).show({duration: 560});
    } else {
        $(divToHide).hide({duration: 200});
    }
}


function getSelectList(inURL, inData, inSelectId, opts) {
    writeToConsole('inURL [' + inURL + '] inData [' + JSON.stringify(inData) + '] inSelectId [' + inSelectId + ']');
    $.ajax({
        url: inURL,
        type: "POST",
        data: inData,
        success: function (data) {
            $(inSelectId).empty();
            if (opts && opts.selectOne) {
                var option = $('<option></option>').text(opts.selectOne);
                $(inSelectId).append(option);
            }
            data.forEach(function (element) {
                var option = $('<option></option>').attr("value", element.value).text(element.text);
                $(inSelectId).append(option);
            });
        },
        error: function () {
            $(inSelectId).empty();
            var option = $('<option></option>').text(opts.errorText);
            $(inSelectId).append(option);
        }
    });
}

function turnOnDebug() {
    globalObj.debugOn = true;
}

function turnOffDebug() {
    globalObj.debugOn = false;
}

function writeToConsole(aMessage) {
    if (globalObj.debugOn) {
        console.log(aMessage);
    }
}

function convertToFloat(inputId) {
    return parseFloat($(inputId).val() || 0) ;
}

function convertToDollar(aFloat) {
    return '$ ' + aFloat.toFixed(2) ;
}