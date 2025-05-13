// wwwroot/ts/filtrarAutores.ts

export function filtrarAutores(inputId: string, selectId: string): void {
    const input = document.getElementById(inputId) as HTMLInputElement | null;
    const select = document.getElementById(selectId) as HTMLSelectElement | null;

    if (!input || !select) return;

    const filtro = input.value.toLowerCase().trim();

    Array.from(select.options).forEach((option) => {
        if (option.value === "0") {
            option.hidden = false; // No ocultar la opción por defecto
            return;
        }

        const visible = option.text.toLowerCase().includes(filtro);
        option.hidden = !visible;
    });
}
