window.onload = function () {
    $("#carYear").val(CARINFO.carYear);
    $("#carName").val(CARINFO.carName);
    $("#carMake").val(CARINFO.carMake);
    $("#carModel").val(CARINFO.carModel);
};

var moveToHomepage = function () {
    console.log("Callback Working!");

    setTimeout(function() {
        //document.location("/home/index");
    }, 2000)
}

$('#updateCarButton').click(function () {
    var car = {};

    var cName = $("#carName").val();
    var cMake = $("#carMake").val();
    var cYear = $("#carYear").val();
    var cModel = $("#carModel").val();

    if (hasData(cName) && hasData(cMake) && hasData(cYear.toString()) && hasData(cModel)) {
        car.Id = CARINFO.carId;
        car.Name = cName;
        car.Make = cMake;
        car.Year = cYear;
        car.Model = cModel;

        updateCar(car, moveToHomepage);
    } else {

        //notify user
    }
});

function hasData(value) {
    if (typeof (value) === "string") {
        if (!value.trim()) {
            return false;
        }
        return true;
    } else if (typeof (value) === "undefined") {
        return false;
    } else {
        return true;
    }
}

function updateCar(car, callback) {
    $.ajax({
        type: "PUT",
        url: Api + 'api/cars/UpdateCar',
        data: car,
        success: function (result) {
            console.log("Response", result);
            callback();
        },
        error: function (error) {
            console.log("Please try again");
        }
    });
};
