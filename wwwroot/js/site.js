function filterTable() {
    const searchValue = document.getElementById("searchBar").value.toLowerCase();
    const table = document.getElementById("xmlTable");
    const rows = table.getElementsByTagName("tr");

    for (let i = 1; i < rows.length; i++) {
        const cells = rows[i].getElementsByTagName("td");
        let match = false;

        for (let j = 0; j < cells.length; j++) {
            if (cells[j].innerText.toLowerCase().includes(searchValue)) {
                match = true;
                break;
            }
        }

        rows[i].style.display = match ? "" : "none";
    }
}

function sortTable(columnIndex) {
    const table = document.getElementById("xmlTable");
    let rows = Array.from(table.rows).slice(1);
    const sortedRows = rows.sort((a, b) => {
        const aText = a.cells[columnIndex].innerText.toLowerCase();
        const bText = b.cells[columnIndex].innerText.toLowerCase();
        return aText > bText ? 1 : -1;
    });

    for (const row of sortedRows) {
        table.tBodies[0].appendChild(row);
    }
}
