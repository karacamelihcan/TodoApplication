﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    // Add butonuna tıklanıldığında addItem fonksiyonu çalışacak.
    $('#add-item-button').on('click', addItem);
    $('.done-checkbox').on('click', function (e) {
        markCompleted(e.target);
    });

});
function addItem() {
    $('#add-item-error').hide();
    $('#add-item-successfull').hide();
    var newTitle = $('#add-item-title').val();

    $.post('/Todo/AddItem', { title: newTitle }, function () {
        window.location = "/Todo";
        $('#add-item-successfull').text("Ekleme Başarılı");
        $('#add-item-successfull').show();
        })
        .fail(function (data) {
            if (data && data.responseJSON) {
                var firstError = data.responseJSON[Object.keys(data.responseJSON)[0]];
                $('#add-item-error').text(firstError);
                $('#add-item-error').show();
            }
        });
}
function markCompleted(checkbox) {
    checkbox.disabled = true;
    $.post('/Todo/MarkDone', { id: checkbox.name }, function () {
        var row = checkbox.parentElement.parentElement;
        $(row).addClass('done');
        window.location = "/Todo";
    });
}