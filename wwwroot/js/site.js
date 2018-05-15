// Write your Javascript code.

var globalObj = {
    debugOn: true
};

function showIfSelected(selectItemId, divToHide, textToCheckList) {
        writeToConsole(selectItemId + ' : ' + divToHide + ' : ' + textToCheckList);
        textToCheckList.some(function(textToCheck) {
            if ($(selectItemId +' option:selected').text() === textToCheck) {
<<<<<<< HEAD
                $(divToHide).show();
                return true ;
            } else {
                $(divToHide).hide();
=======
                $(divToHide).show({duration: 560});
                return true ;
            } else {
                $(divToHide).hide({duration: 200});
>>>>>>> 319af4b90901d9ac574cca66ad7e9e208ebf1b38
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
