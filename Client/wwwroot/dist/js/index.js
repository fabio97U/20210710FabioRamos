function mostrarModal(modelid) {
    $("#" + modelid).modal("show")
}
function ocultarModal(modelid) {
    $("#" + modelid).modal("hide")
}

function saveAsFile(filename, bytesBase64) {
    if (navigator.msSaveBlob) {
        //Download document in Edge browser
        var data = window.atob(bytesBase64);
        var bytes = new Uint8Array(data.length);
        for (var i = 0; i < data.length; i++) {
            bytes[i] = data.charCodeAt(i);
        }
        var blob = new Blob([bytes.buffer], { type: "application/octet-stream" });
        navigator.msSaveBlob(blob, filename);
    }
    else {
        var link = document.createElement('a');
        link.download = filename;
        link.href = "data:application/octet-stream;base64," + bytesBase64;
        document.body.appendChild(link); // Needed for Firefox
        link.click();
        document.body.removeChild(link);
    }
}

function opcionPadre(parametro) {
    var ruta = $($($(".nav-item.dropdown.active")[0]).find(".nav-link-title")[0]).text().trim()
    return ruta;
}
function opcionHijo(parametro) {
    var ruta = $($(".dropdown-item.active")[0]).text().trim()
    return ruta;
}

function popupwindow(url, w=1000, h=900) {
    var left = (screen.width / 2) - (w / 2);
    var top = (screen.height / 2) - (h / 2);
    return window.open(url, "Report", 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
}

function mostraroOcultarArchivo(id) {
    var filePath = $("#" + id).val();
    var file_ext = filePath.substr(filePath.lastIndexOf('.') + 1, filePath.length);
    if (file_ext == "pdf") {//Es PDF
        $("#" + id + "_pdf").removeClass("d-none");
        $("#" + id + "_image").addClass("d-none");
    } else {//Es image
        $("#" + id + "_image").removeClass("d-none");
        $("#" + id + "_pdf").addClass("d-none")
    }
    return file_ext;
}

function mostrarArchivoBase64(archivobase64, extension) {
    var mContentType = `image/${extension}`;
    if (extension == "pdf")
        mContentType = "application/pdf";

    let pdfWindow = window.open("")
    pdfWindow.document.write("<iframe width='100%' height='100%' src='data:" + mContentType + ";base64, " + encodeURI(archivobase64) + "'></iframe>")
    pdfWindow.document.close();
}
