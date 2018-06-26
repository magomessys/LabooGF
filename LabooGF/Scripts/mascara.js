$(function () {
    //$("input[data-tipo='cpf']").mask("000.000.000-00");
    $('.datemask').inputmask('dd/mm/yyyy', { 'placeholder': 'dd/mm/yyyy' })
    $("input[data-tipo='data']").mask("00/00/0000");
    //$("input[data-tipo='moeda']").mask("000.000.000,00", { reverse: true });

    //Mascara Telefone DDD + 8 ou 9 digitos. 
    $(".telefone").mask("(99) 9999-9999?9");
    $(".telefone").blur(function (event) {
        if ($(this).val().length === 15) {
            $('.telefone').mask('(99) 99999-999?9');
        } else {
            $('.telefone').mask('(99) 9999-9999?9');
        }
    });
});