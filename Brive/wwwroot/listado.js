function buscar_producto() {
    var codigo_producto = document.getElementById("codigo_barras").value, sucursal = document.getElementById("list_sucursales").value;
    fetch("/Home/stock_producto?codigo_producto=" + codigo_producto + "&sucursal=" + sucursal)
        .then(response => response.json())
        .then(data => mostrar_producto(data));
}
function mostrar_producto(data) {
    document.getElementById("listado_productos").innerHTML = "<td>"+data.producto+"</td><td>"+data.codigo_producto+"</td><td>"+data.stock+"</td><td>"+data.precio+"</td><td>"+data.sucursal+"</td>";
}

function Listar_sucursales() {
    fetch("/Home/Listar_sucursal")
        .then(response => response.json())
        .then(data => mostrar_sucursales(data.lista_sucursales));
}
function mostrar_sucursales(data) {
    let sucursales = "<option selected disabled value=''>Selecciona Sucursal</option>";
    for (let x = 0; x < data.length; x++) {
        sucursales = sucursales + "<option value='" + data[x].id_sucursal + "'>" + data[x].sucursal + "</option>";
    }
    document.getElementById("list_sucursales").innerHTML = sucursales;
}
Listar_sucursales();