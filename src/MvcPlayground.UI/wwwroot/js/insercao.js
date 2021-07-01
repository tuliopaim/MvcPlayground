$(function () {
    $("#add-endereco").on('click', adicionarEndereco);
});

function adicionarEndereco() {

    let index = obterIndexDoNovoEndereco();

    let html = obtemHtmlDeNovoEndereco(index);

    $("#dinamicamente").append(html);

    rebindValidators();
}

function obterIndexDoNovoEndereco() {
    return $("#for .endereco").length + $("#dinamicamente .endereco").length;
}

function obtemHtmlDeNovoEndereco(index) {
    return '<div class="endereco">' + 
                   '<div class="form-row">'+
                        '<div class="form-group col-4">'+
                           '<label class="control-label" for="Enderecos_' + index +'__Cep">Cep</label>' +
                            '<input class="form-control valid" placeholder="123456" type="text" data-val="true" data-val-required="Obrigatório" id="Enderecos_' + index +'__Cep" name="Enderecos[' + index +'].Cep" aria-describedby="Enderecos_' + index +'__Cep-error" aria-invalid="false">' +
                            '<span class="text-danger field-validation-valid" data-valmsg-for="Enderecos[' + index +'].Cep" data-valmsg-replace="true"></span>' +
                        '</div>' +
                        '<div class="form-group col-4">' +
                            '<label class="control-label" for="Enderecos_' + index +'__Logradouro">Logradouro</label>'+
                            '<input class="form-control" placeholder="Av. Araxá" type="text" data-val="true" data-val-required="Obrigatório" id="Enderecos_' + index +'__Logradouro" name="Enderecos[' + index +'].Logradouro">'+
                            '<span class="text-danger field-validation-valid" data-valmsg-for="Enderecos[' + index +'].Logradouro" data-valmsg-replace="true"></span>'+
                        '</div>'+
                        '<div class="form-group col-4">' +
                            '<label class="control-label" for="Enderecos_' + index +'__Complemento">Complemento</label>' +
                            '<input class="form-control" placeholder="Quadra X Lote Y Ap Z" type="text" data-val="true" data-val-required="Obrigatório" id="Enderecos_' + index +'__Complemento" name="Enderecos[' + index +'].Complemento">' +
                            '<span class="text-danger field-validation-valid" data-valmsg-for="Enderecos[' + index +'].Complemento" data-valmsg-replace="true"></span>'+
                        '</div>'+
                    '</div>' +
                    '<div class="form-row">'+
                        '<div class="form-group col-4">' +
                            '<label class="control-label" for="Enderecos_' + index +'__Bairro">Bairro</label>' +
                            '<input class="form-control" placeholder="João" type="text" data-val="true" data-val-required="Obrigatório" id="Enderecos_' + index +'__Bairro" name="Enderecos[' + index +'].Bairro">' +
                            '<span class="text-danger field-validation-valid" data-valmsg-for="Enderecos[' + index +'].Bairro" data-valmsg-replace="true"></span>' +
                        '</div>' +
                        '<div class="form-group col-4">' +
                            '<label class="control-label" for="Enderecos_' + index +'__Cidade">Cidade</label>' +
                            '<input class="form-control" placeholder="da Silva" type="text" data-val="true" data-val-required="Obrigatório" id="Enderecos_' + index +'__Cidade" name="Enderecos[' + index +'].Cidade">' +
                            '<span class="text-danger field-validation-valid" data-valmsg-for="Enderecos[' + index +'].Cidade" data-valmsg-replace="true"></span>' +
                        '</div>' +
                        '<div class="form-group col-4">' +
                            '<label class="control-label" for="Enderecos_' + index +'__Estado">Estado</label>' +
                            '<input class="form-control" placeholder="GO" type="text" data-val="true" data-val-required="Obrigatório" id="Enderecos_' + index +'__Estado" name="Enderecos[' + index +'].Estado">' +
                            '<span class="text-danger field-validation-valid" data-valmsg-for="Enderecos[' + index +'].Estado" data-valmsg-replace="true"></span>' +
                        '</div>' +
                    '</div>'+
                    '<hr/>' +
                '</div>';
}

function rebindValidators() {
    const $form = $("form");
    $form.unbind();
    $form.data("validator", null);
    $.validator.unobtrusive.parse($form);
    $form.validate($form.data("unobtrusiveValidation").options);
}