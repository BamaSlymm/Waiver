// Write your Javascript code.

var globalObj = {
    debugOn: true
};

function showIfSelected(selectItemId, divToHide, textToCheckList) {
        writeToConsole(selectItemId + ' : ' + divToHide + ' : ' + textToCheckList);
        textToCheckList.some(function(textToCheck) {
            if ($(selectItemId +' option:selected').text() === textToCheck) {
                $(divToHide).show();
                return true ;
            } else {
                $(divToHide).hide();
                return false;
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
