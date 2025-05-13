window.filtrarAutores = function (inputId, selectId) {
    const input = document.getElementById(inputId);
    const select = document.getElementById(selectId);
    if (!input || !select) return;

    const filtro = input.value.toLowerCase().trim();
    let visibleCount = 0;

    Array.from(select.options).forEach(option => {
        if (option.value === "0") {
            option.style.display = "block";
            return;
        }

        const visible = option.text.toLowerCase().includes(filtro);
        option.style.display = visible ? "block" : "none";
        if (visible) visibleCount++;
    });

    select.size = filtro.length > 0 ? Math.min(visibleCount + 1, 6) : 1;

    // 💡 Este evento hace que cuando selecciones algo se cierre el select
    select.onchange = () => {
        select.size = 1; // lo cierra al hacer una selección
        input.value = ""; // opcional: limpiar búsqueda si querés
    };
};
