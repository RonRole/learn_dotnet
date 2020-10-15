// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const submitGameForm = (row,col) => {
    const gameForm = document.forms.gameForm
    const xInput = document.createElement('input')
    xInput.name = 'x'
    xInput.type = 'hidden'
    xInput.value = col
    const yInput = document.createElement('input')
    yInput.name = 'y'
    yInput.type = 'hidden'
    yInput.value = row
    gameForm.appendChild(xInput)
    gameForm.appendChild(yInput)
    gameForm.submit();
}