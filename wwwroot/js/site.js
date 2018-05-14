// Write your Javascript code.

var globalObj = {
    debugOn: true
};
function showIfSelected(selectItemId, divToHide, textToCheck) {
        writeToConsole(selectItemId + ' : ' + divToHide + ' : ' + textToCheck);
        if ($(selectItemId +' option:selected').text() === textToCheck) {
            $(divToHide).show();
        } else {
            $(divToHide).hide();
        }        
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
