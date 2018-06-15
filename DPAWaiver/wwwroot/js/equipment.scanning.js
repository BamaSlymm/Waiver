   $(document).ready(function () {
        showIfSelected('#newOrReplace', ['#currentMakeDiv','#modelAndAcquisitionDiv'], { valueList: ['0','1'] });
        showIfSelected('#multiFunctionConsidered', ['#multiFunctionReasonDiv'], {valueList: ['0'] });
        showIfSelected('#scannerType', ['#otherScannerTypeDiv'], {valueList: ['0'] });
        showIfSelected('#acquisitionType', ['#solicitationSubDiv'], {valueList: ['1']});
        showIfSelected('#acquisitionType', ['#statepriceSubDiv'], {valueList: ['2']});
        showIfSelected('#leaseOrPurchase', ['#leaseDataDiv'], {valueList: ['0']});
        showIfSelected('#leaseOrPurchase', ['#purchaseDataDiv'], {valueList: ['1']});
        showIfSelected('#additionalWorkspaceRequired', ['#additionalWorkspaceDiv'], {valueList: ['1']});
        calculateTotalEquipmentCost();
        calculateTotalAnnualPersonnelCost();
        calculateTotalSoftwareCost();
        calculateTotalAnnualLicenseCost();
        calculateTotalSpaceCost();
        calculateTotalOneTimeCost();
        calculateTotalCostOfOwnership();
    });


    $('#newOrReplace').on('change',function() {
        showIfSelected('#newOrReplace', ['#currentMakeDiv','#modelAndAcquisitionDiv'], {valueList: ['0','1']});
    });

    $('#multiFunctionConsidered').on('change',function() {
        showIfSelected('#multiFunctionConsidered', ['#multiFunctionReasonDiv'], {valueList: ['0']});
    });

    $('#scannerType').on('change',function() {
        showIfSelected('#scannerType', ['#otherScannerTypeDiv'], {valueList: ['0']});
    });

    $("#acquisitionType").on("change", function () {
        showIfSelected('#acquisitionType', ['#solicitationSubDiv'], {valueList: ['1']});
        showIfSelected('#acquisitionType', ['#statepriceSubDiv'], {valueList: ['2']});
    });

    $("#additionalWorkspaceRequired").on("change", function () {
        showIfSelected('#additionalWorkspaceRequired', ['#additionalWorkspaceDiv'], {valueList: ['1']});
    });


    $("#leaseOrPurchase").on("change", function () {
        showIfSelected('#leaseOrPurchase', ['#leaseDataDiv'], {valueList: ['0']});
        showIfSelected('#leaseOrPurchase', ['#purchaseDataDiv'], {valueList: ['1']});
    });

    $("#estimatedCost, #annualMaintenanceCostPerYear, #suppliesCost").on("change paste keyup", function () {
           calculateTotalEquipmentCost();
           calculateTotalCostOfOwnership();
    });

    function calculateTotalEquipmentCost() {
        $('#totalEquipmentCost').val(convertFloatToDollarAsString(getTotalEquipmentCost()));
    }

    function getTotalEquipmentCost() {
        let estimatedCost = convertToFloat('#estimatedCost') ;
        let annualMaintenanceCostPerYear = convertToFloat('#annualMaintenanceCostPerYear') ;
        let suppliesCost = convertToFloat('#suppliesCost') ;
        return estimatedCost+annualMaintenanceCostPerYear+suppliesCost;
    }



    $("#productionFTE, #hoursPerFTEPerWeek, #fullyLoadedHourlyRatePerFTE").on("change paste keyup", function () {
           calculateTotalAnnualPersonnelCost();
           calculateTotalCostOfOwnership();
    });

    function calculateTotalAnnualPersonnelCost() {
        $('#totalAnnualPersonnelCost').val(convertFloatToDollarAsString(getTotalAnnualPersonnelCost()));
    }

    function getTotalAnnualPersonnelCost() {
        let productionFTE = convertToFloat('#productionFTE');
        let hoursPerFTEperWeek = convertToFloat('#hoursPerFTEPerWeek');
        let fullyLoadedHourlyRatePerFTE = convertToFloat('#fullyLoadedHourlyRatePerFTE');
        return productionFTE*hoursPerFTEperWeek*fullyLoadedHourlyRatePerFTE;
    }

    $("#totalSpaceRequiredInSQFT, #costPerSQFT, #annualAmountForUtilities").on("change paste keyup", function () {
           calculateTotalSpaceCost();
           calculateTotalCostOfOwnership();
    });

    function calculateTotalSpaceCost() {
        $('#totalSpaceCost').val(convertFloatToDollarAsString(getTotalSpaceCost()));
    }

    function getTotalSpaceCost() {
        let totalSpaceRequiredInSQFT = convertToFloat('#totalSpaceRequiredInSQFT');
        let costPerSQFT = convertToFloat('#costPerSQFT');
        let annualAmountForUtilities = convertToFloat('#annualAmountForUtilities');

        return totalSpaceRequiredInSQFT * costPerSQFT + annualAmountForUtilities;
    }


    $("#softwareCost, #annualLicenseFee, #numberOfLicenses, #annualMaintenanceCost").on("change paste keyup", function () {
           calculateTotalSoftwareCost();
           calculateTotalCostOfOwnership();
    });

    function calculateTotalSoftwareCost() {
        $('#totalSoftwareCosts').val(convertFloatToDollarAsString(getTotalSoftwareCost()));
    }

    function getTotalSoftwareCost() {
        let softwareCost = convertToFloat('#softwareCost');
        let annualLicenseFee = convertToFloat('#annualLicenseFee');
        let numberOfLicenses = convertToFloat('#numberOfLicenses');
        let annualMaintenanceCost = convertToFloat('#annualMaintenanceCost');
        return softwareCost + (annualLicenseFee * numberOfLicenses) + annualMaintenanceCost;
    }



    $("#annualLicenseFee, #numberOfLicenses").on("change paste keyup", function () {
           calculateTotalAnnualLicenseCost();
           calculateTotalCostOfOwnership();
    });

    function calculateTotalAnnualLicenseCost() {
        $('#totalAnnualLicenseCost').val(convertFloatToDollarAsString(getTotalSoftwareCost()));
    }

    function getTotalAnnualLicenseCost() {
        let annualLicenseFee = convertToFloat('#annualLicenseFee');
        let numberOfLicenses = convertToFloat('#numberOfLicenses');
        return annualLicenseFee * numberOfLicenses ;
    }

    $("#computerCosts, #furnitureCosts, #cubiclePartitionCosts, #constructionCosts, #miscellaneousCosts").on("change paste keyup", function () {
           calculateTotalOneTimeCost();
           calculateTotalCostOfOwnership();
    });

    function calculateTotalOneTimeCost() {
        $('#totalAdditionalOneTimeCosts').val(convertFloatToDollarAsString(getTotalOneTimeCost()));
    }

    function getTotalOneTimeCost() {
        let computerCosts = convertToFloat('#computerCosts');
        let furnitureCosts = convertToFloat('#furnitureCosts');
        let cubiclePartitionCosts = convertToFloat('#cubiclePartitionCosts');
        let constructionCosts = convertToFloat('#constructionCosts');
        let miscellaneousCosts = convertToFloat('#miscellaneousCosts');
        return computerCosts + furnitureCosts + cubiclePartitionCosts + constructionCosts + miscellaneousCosts;
    }

    function getTotalCostOfOwnership() {
         return getTotalEquipmentCost() + getTotalAnnualPersonnelCost() + getTotalOneTimeCost() + getTotalSpaceCost() + getTotalSoftwareCost() ; 
    }

    function calculateTotalCostOfOwnership() {
        $('#totalCostOfOwnership').val(convertFloatToDollarAsString(getTotalCostOfOwnership()));
    }
