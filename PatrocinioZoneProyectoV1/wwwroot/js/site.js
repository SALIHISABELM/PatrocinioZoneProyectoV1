// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

<script>
    document.querySelector('form').addEventListener('submit', function (e) {
        const zonaSelect = document.getElementById('ZonaPatrocinio');
    if (zonaSelect && !zonaSelect.value) {
        e.preventDefault();
    alert("Por favor, seleccione una zona de patrocinio.");
    zonaSelect.focus();
        }

        // Puedes agregar más validaciones aquí...
    });
</script>
