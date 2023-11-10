// 搜索功能
document.getElementById("search-button").addEventListener("click", function () {
    var searchTerm = document.getElementById("search-input").value.toLowerCase();
    var items = document.querySelectorAll(".searchable-item");

    items.forEach(function (item) {
        var itemText = item.textContent.toLowerCase();
        if (itemText.includes(searchTerm)) {
            item.style.display = "block";
        } else {
            item.style.display = "none";
        }
    });
});
// 筛选功能
document.getElementById("filter-button").addEventListener("click", function () {
    var filterValue = document.getElementById("filter-select").value;
    var items = document.querySelectorAll(".filterable-item");

    items.forEach(function (item) {
        var itemValue = item.getAttribute("data-filter-value");
        if (filterValue === "all" || filterValue === itemValue) {
            item.style.display = "block";
        } else {
            item.style.display = "none";
        }
    });
});
// 排序功能
document.getElementById("sort-button").addEventListener("click", function () {
    var sortBy = document.getElementById("price-sort").value;
    var items = document.querySelectorAll(".sortable-item");

    var sortedItems = Array.from(items).sort(function (a, b) {
        var aValue = parseFloat(a.getAttribute("data-price"));
        var bValue = parseFloat(b.getAttribute("data-price"));

        if (sortBy === "asc") {
            return aValue - bValue;
        } else {
            return bValue - aValue;
        }
    });

    var container = document.querySelector(".container4");
    container.innerHTML = "";

    sortedItems.forEach(function (item) {
        container.appendChild(item);
    });
});