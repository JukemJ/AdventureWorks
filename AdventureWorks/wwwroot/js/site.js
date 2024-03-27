// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//const searchField = document.getElementById("CustomerSearchField")
//const searchButton = document.getElementById("searchButton")
//const resetButton = document.getElementById("resetButton")
//searchButton.addEventListener('click', updateCustomerList)
//resetButton.addEventListener('click', resetCustomerList)
//const dataRows = document.getElementsByClassName("data-row")
//const customersTable = document.getElementById("customersTable")
let table = new DataTable("#customersTable")

function updateCustomerList() {
    for (let row of dataRows) {
        //row.style.display = "table-row"
        let text = row.innerText.split('Edit')[0].toLowerCase()
        let searchText = searchField.value.toLowerCase()
        
        //console.log(text, searchField.value, text.includes(searchText))
        if (!text.includes(searchField.value)) row.style.display = "none"
        else row.style.display = "table-row"
    }
}

function resetCustomerList() {
    searchField.value = ""
    for (let row of dataRows) row.style.display = "table-row"

}

