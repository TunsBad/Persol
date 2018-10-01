window.onload = function () {
    getAllCars();
}

function getAllCars() {
    $.ajax({
        url: Api + 'api/cars/GetAllCars',
        type: 'GET',
        success: function (data) {
            //console.log('data', data);
            listCars(data)
        }
    });
}

function listCars(data) {
    var rowoutput = "";

    $('#carlist').replaceWith('<tbody id="carlist"></div>')

    for (var i = 0; i < data.length; i += 1) {
        //console.log(data[i]);

        rowoutput = rowoutput + '<tr><td>' + data[i].Name + ' </td><td>' + data[i].Make + '</td>\
            <td>' + data[i].Year + '</td><td>' + data[i].Model + '</td>\
            <td><a class="" href="/home/Update?carId='+ data[i].Id +'&carName=' + data[i].Name + '&carMake='+ data[i].Make +'&carYear='+ data[i].Year +'&carModel='+ data[i].Model +'">Update</a>&nbsp;\
            &nbsp;<button onclick=deleteCar("' + data[i].Id + '")>Delete</button></td></tr>'
    }

    $("#carlist").html(rowoutput);
}

function deleteCar(id) {
    $.ajax({
        url: Api + 'api/cars/DeleteCar?id='+ id,
        type: 'GET',
        success: function (data) {
            //console.log('data', data);
            getAllCars();
        }
    });
}