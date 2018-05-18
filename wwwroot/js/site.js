// Write your Javascript code.

var globalObj = {
    debugOn: true
};

function showIfSelected(selectItemId, divToHide, textToCheckList) {
        writeToConsole(selectItemId + ' : ' + divToHide + ' : ' + textToCheckList);
        textToCheckList.some(function(textToCheck) {
            if ($(selectItemId +' option:selected').text() === textToCheck) {
                $(divToHide).show({duration: 560});
                return true ;
            } else {
                $(divToHide).hide({duration: 200});
                return false;
            }        
        });
}

function getSelectList(inURL,inData, inSelectId, opts) {
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
    globalObj.debugOn = true ;
}

function turnOffDebug() {
    globalObj.debugOn = false ;
}

function writeToConsole(aMessage) {
    if (globalObj.debugOn) {
        console.log(aMessage);
    }
}
