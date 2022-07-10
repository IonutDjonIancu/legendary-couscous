// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// variables
const btn = $('#btn');
const mapDiv = $('#map');
let camerasData = [];
let col1 = [];
let col2 = [];
let col3 = [];
let col4 = [];

let column3Body = $('#column3Body');
let column5Body = $('#column5Body');
let column15Body = $('#column15Body');
let columnOtherBody = $('#columnOtherBody');

let map;

// functions

const initMap = (lati, long) => {

    //const pos = { lat: 52.0893793, lng: 5.1080063 };
    const pos = { lat: lati, lng: long };

    map = new google.maps.Map(document.getElementById('map'), {
        center: pos,
        zoom: 15,
    });

    const marker = new google.maps.Marker({
        position: pos,
        map: map,
    });

}


const getCamNumber = (camera) => {

    const cameraCode = camera.split(' ')[0];
    const cameraNumber = cameraCode.split('-')[2];
    let num = parseInt(cameraNumber);

    if (isNaN(num)) {
        return 0;
    } else {
        return num;
    }
} 

const distributeCamera = (camera, cameraNum) => {

    let isZero = cameraNum === 0
    let isOne = cameraNum % 3 === 0;
    let isTwo = cameraNum % 5 === 0;
    let isThree = cameraNum % 3 === 0 && cameraNum % 5 === 0;

    if (isZero) {
        col4.push(camera);
        return;
    }

    if (isThree) {
        col3.push(camera);
        return;
    } else if (isOne) {
        col1.push(camera);
        return;
    } else if (isTwo) {
        col2.push(camera);
        return;
    } else {
        col4.push(camera);
        return;
    }

}

const filterCameras = (cameras) => {

    cameras.forEach(e => {

        let cameraNum = getCamNumber(e.name);

        distributeCamera(e, cameraNum);

    });
}

const buildHtml = (e) => {

    var location = `${e.latitude}|${e.longitude}`;

    let html = `
        <tr>
            <td scope="row" class="disableCaret">
                <a value=${location} style="font-size:10px;">${e.name} | ${e.latitude} | ${e.longitude}</a>
            </td>
        </tr>
    `;

    return html;
}

const displayCameras = () => {

    col1.forEach(e => {
        column3Body.append(buildHtml(e));
    });

    col2.forEach(e => {
        column5Body.append(buildHtml(e));
    });

    col3.forEach(e => {
        column15Body.append(buildHtml(e));
    });

    col4.forEach(e => {
        columnOtherBody.append(buildHtml(e));
    });
}

// events
btn.on('click', () => {

    fetch('https://localhost:7290/api/getcameras')
        .then(response => response.json())
        .then(data => {
            camerasData = data;

            filterCameras(camerasData);

            displayCameras();
            

            window.initMap = initMap(52.0893793, 5.1080063);

            $('a').on('click', (e) => {

                var location = e.target.getAttribute('value');
                var lati = location.split('|')[0];
                var long = location.split('|')[1];

                var latiNum = parseFloat(lati);
                var longNum = parseFloat(long);

                map = new google.maps.Map(document.getElementById('map'), {
                    center: { lat: latiNum, lng: longNum },
                    zoom: 15
                });

                const marker = new google.maps.Marker({
                    position: { lat: latiNum, lng: longNum },
                    map: map,
                });
            });
        }
    );




});



// at startup



