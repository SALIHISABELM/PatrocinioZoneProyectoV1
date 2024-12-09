// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.getElementById("myForm").addEventListener("submit", function (event) {
    var selectedRadio = document.querySelector('input[name="ZonaDePatrocinioID"]:checked');
    if (!selectedRadio) {
        event.preventDefault(); // Previene el envío del formulario
        e.preventDefault();
    alert("Por favor, seleccione una zona de patrocinio.");
    zonaSelect.focus();
        }

        // Puedes agregar más validaciones aquí...
    });
</script>
