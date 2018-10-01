var today = new Date();

window.onload = function () {
    $("#carYear").val(today.getFullYear());
};

var setDefaults = function () {
    $("#carName").val("");
    $("#carMake").val("");
    $("#carYear").val(today.getFullYear());
    $("#carModel").val("");
};

$('#storeCar').click(function () {
    var car = {};
    
    var cName = $("#carName").val();
    var cMake = $("#carMake").val();
    var cYear = $("#carYear").val();
    var cModel = $("#carModel").val();

    if (hasData(cName) && hasData(cMake) && hasData(cYear.toString()) && hasData(cModel)) {
        car.Name = cName;
        car.Make = cMake;
        car.Year = cYear;
        car.Model = cModel;

        saveNewCar(car, setDefaults);
    } else {

        console.log("All fields are required!")
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

function saveNewCar(car, callback) {
    $.ajax({
        type: "POST",
        url: Api + 'api/cars/StoreCar',
        data: car,
        success: function (result) {
            //console.log("Response", result);
            callback();
        },
        error: function (error) {
            console.log("Please try again");
        }
    });
};
