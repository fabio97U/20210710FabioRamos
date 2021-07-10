function GraficoBarra(id_div, series, categories) {
    var options = {
        chart: {
            type: 'bar'
        },
        series: JSON.parse(series),
        xaxis: {
            categories: JSON.parse(categories)
        }
    };
    document.getElementById(id_div).innerHTML = "";
    var chart = new ApexCharts(document.querySelector("#" + id_div), options);
    chart.render();
}