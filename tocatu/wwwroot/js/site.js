// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



console.log("hola mundo");

$("#btn-unir").click(function () {
    Swal.fire({
        position: 'top-end',
        icon: 'success',
        title: 'Te has unido satisfactoriamente',
        showConfirmButton: false,
        timer: 2000
    })
})

$("#btn-crear").click(function () {
    Swal.fire({
        position: 'top-end',
        icon: 'success',
        title: 'Creado satisfactoriamente',
        showConfirmButton: false,
        timer: 2000
    })
})