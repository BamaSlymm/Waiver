// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

var globalObj = {
    debugOn: true
};

function showWhenTrue(divsToShow, opts) {
    writeToConsole(divsToShow + ' : ' + JSON.stringify(opts));
    let matchFound = false ;

    if (opts && opts.cb) {
        matchFound = opts.cb();
        writeToConsole('match found for cb ' + matchFound);
    }

    showDOMElements(divsToShow,opts, matchFound);
}
function showIfSelected(selectItemId, divsToShow, opts) {
    writeToConsole(selectItemId + ' : ' + divsToShow + ' : ' + JSON.stringify(opts));
    let matchFound = false ;

    
    if ((opts && opts.textList) || (opts && opts.valueList)) {
        let myList = [];

        if (opts && opts.textList) {
            myList = opts.textList;
        }
        if (opts && opts.valueList) {
            myList = opts.valueList;
        }

        matchFound = myList.some(function (toCheck) {
            let matchFound = false ;
            
            if (opts && opts.textList) {
                matchFound = ( $(selectItemId + ' option:selected').text() === toCheck );
                writeToConsole('matchFound : ' + matchFound + ' : ' + ' val ' + $(selectItemId + ' option:selected').text());
            }

            if (opts && opts.valueList) {
                matchFound = ( $(selectItemId + ' option:selected').val() === toCheck );
                writeToConsole('matchFound : ' + matchFound + ' : ' + ' val ' + $(selectItemId + ' option:selected').val());
            }
            return matchFound;
        }); 
        showDOMElements(divsToShow,opts, matchFound);
    }
    
}

function showDOMElements(elementIDs, opts, matchFound) {
    writeToConsole(elementIDs + ' : ' + JSON.stringify(opts) + ' : ' + matchFound);
    if (opts && opts.hide) {
        if (matchFound) {
            elementIDs.forEach(function(anId) {
                $(anId).hide({duration: 560});
            });
            return true;
        } else {
            elementIDs.forEach(function(anId) {
                $(anId).show({duration: 200});
            });
            return false;
        }
    }

    if (matchFound) {
        elementIDs.forEach(function(anId) {
            $(anId).show({duration: 560});
        });
        return true;
    } else {
        elementIDs.forEach(function(anId) {
            $(anId).hide({duration: 200});
        });
        return false;
    }
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
            if (opts && opts.optsToAdd) {
                opts.optsToAdd.forEach(function(anOption) {
                    $(inSelectId).append(anOption);
                });
            }
            data.forEach(function (element) {
                var option = $('<option></option>').attr("value", element.value).text(element.text);
                $(inSelectId).append(option);
            });
        },
        error: function () {
            $(inSelectId).empty();
            var option = $('<option></option>').text('An error has occurred');
            $(inSelectId).append(option);
        }
    });
}

/**
 * 
 * @param {string} inURL 
 * @param {string} inData 
 * @param {function} onSuccess gets a JSON data structure
 * @param {function} onError
 */
function getJSONData(inURL, inData, onSuccess, onError) {
    writeToConsole('inURL [' + inURL + '] inData [' + JSON.stringify(inData) );
    $.ajax({
        url: inURL,
        type: "POST",
        data: inData,
        success: function(data) {
            onSuccess(data);
        },
        error: function() {
            onError();
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

function convertFloatToDollarAsString(aFloat,decimalPlaces) {
    if (typeof decimalPlaces === 'undefined') {
        decimalPlaces = 2 ;
    }
    return '$ ' + aFloat.toFixed(decimalPlaces) ;
}

function roundFloat(aFloat,decimalPlaces) {
    if (typeof decimalPlaces === 'undefined') {
        decimalPlaces = 2 ;
    }
    return aFloat.toFixed(decimalPlaces) ;
}

function calculatePerItemCost(totalCost, itemCount, decimalPlaces) {
    writeToConsole('totalCost=[' + totalCost + '] itemCount=[' +itemCount +'] decimalPlaces=[' + decimalPlaces + ']');
    if (typeof itemCount === 'undefined') {
        return ;
    }
    if (typeof decimalPlaces === 'undefined') {
        decimalPlaces = 2 ;
    }
    if (itemCount == 0) {
        return Number(0).toFixed(decimalPlaces);
    }
    return (totalCost/itemCount).toFixed(decimalPlaces);
}