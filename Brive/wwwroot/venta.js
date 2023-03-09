var productos = [];
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
function Agregar_carrito() {
    document.getElementById("list_sucursales").disabled=true;
    var codigo_producto = document.getElementById("codigo_barras").value, sucursal = document.getElementById("list_sucursales").value;
    productos.push(document.getElementById("codigo_barras").value);
    fetch("/Home/stock_producto?codigo_producto=" + codigo_producto + "&sucursal=" + sucursal)
        .then(response => response.json())
        .then(data => carrito(data));
}
function carrito(data) {
    if (data.stock > 0) {
        let tbl = document.getElementById("listado_productos").innerHTML;
        document.getElementById("listado_productos").innerHTML = tbl+"<td>" + data.producto + "</td><td>" + data.codigo_producto + "</td><td>1</td><td>" + data.precio + "</td><td>" + data.sucursal + "</td>";
    }
    else {
        alert("Error en Compra!\nEl sistema no cuenta con stock!");
    }
}
function finalizar_compra() {
    if (productos.length > 0) {
        let json_items = "";
        for (let x = 0; x < productos.length; x++) {
            if (x > 0) {
                json_items = json_items + ",{\"codigo_producto\":" + productos[x] + ",\"cantidad\":1}";
            }
            else {
                json_items = "{\"codigo_producto\":" + productos[x] + ",\"cantidad\":1}";
            }
        }
        let json_compra = "{\"sucursal\":" + document.getElementById("list_sucursales").value + ",\"lista_compra\":[" + json_items + "]}";
        fetch('/Home/Compra', {
            method: "POST",
            body: json_compra,
            headers: { "Content-type": "application/json; charset=UTF-8" }
        })
            .then(response => response.json())
            .then(json => mostrar_compra(json));
        /*
        fetch("/Home/Compra")
        body: json_items
            .then(response => response.json())
            .then(data => mostrar_compra(data));*/
        document.getElementById("list_sucursales").disabled = false;
        document.getElementById("listado_productos").innerHTML = "";
    }
}
function mostrar_compra(data) {
    if (data!="0")
        alert("Compra Exitosa!");
    else
        alert("Error en compra!");
}