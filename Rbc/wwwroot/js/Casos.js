$("#modalSelecionarCaso").on("shown.bs.modal", function () {
    mostrarLoadingCasos();
    $.ajax(
        {
            url: "/Rbc/RetornarCasosAdicionados",
            type: "GET",
            contentType: "application/json",
            success: function (data) {
                casosAdicionados = data;
                esconderLoadingCasos();
                renderizarCasos(data);
            }
        });
});


$("#modalSelecionarCaso").on("hidden.bs.modal", function () {
    $("#casosAdicionados").html("");
    casosAdicionados = [];
});

$("#novo").click(function () {
    $("#modalSelecionarCaso").modal("hide");
    $("#modalAdicionarCaso").modal("show");
});

$("#selecionarExistente").click(function () {
    $("#modalAdicionarCaso").modal("hide");
    $("#modalSelecionarCaso").modal("show");
});

function esconderLoadingCasos() {
    $("#loadingEscolherCaso").hide();
}
function mostrarLoadingCasos() {
    $("#loadingEscolherCaso").show();
}

function renderizarCasos(casos) {
    if (casos.length > 0) {
        var itens = "";
        casos.forEach(function (element) {
            var itemPai = '<div class="mb-2"><b><i class="fa fa-hashtag"></i>' + element.id + '</b> <div class="float-right"><button data-id="' + element.id + '" class="btn btn-primary mr-2 selecionar">SELECIONAR</button><button class="btn btn-light collapseButton" data-toggle="collapse" data-target="#collapse_' + element.id + '"><i class="fa fa-angle-down"></i></button></div></div>';
            var itemFilho = montarHtmlCollapse(element);
            var li = '<li class="list-group-item">' + itemPai + itemFilho + '</li>';
            itens += li;
        });

        var html = '<div class="card"><ul class="list-group list-group-flush">' + itens + '</ul></div >';
        $("#casosAdicionados").html(html);
    } else {
        $("#casosAdicionados").html("<div class='alert alert-warning' role='alert'><i class='fa fa-warning'></i> Nenhum caso encontrado.</div >");
    }
}

function montarHtmlCollapse(caso) {
    var head = `<thead>
                             <tr>
                                <th>Nº Parc. Sexuais</th>
                                <th>Primeira Rel.</th>
                                <th>Nº Gestações</th>
                                <th>Fuma</th>
                                <th>Fuma (anos)</th>
                                <th>Packs/Year</th>
                                <th>Contraceptivo Hormonal</th>
                                <th>Contraceptivo H. (anos)</th>
                                <th>DIU</th>
                                <th>DIU (anos)</th>
                                <th>DST</th>
                                <th>Nº DST</th>
                                <th>Condiloma</th>
                                <th>Condiloma Uterino</th>
                                <th>Condiloma Vaginal</th>
                                <th>Condiloma Vulvo-perineal</th>
                                <th>Sífilis</th>
                                <th>Inflamação Pélvica</th>
                                <th>Herpes Genital</th>
                                <th>Molusco Contagioso</th>
                                <th>AIDS</th>
                                <th>HIV</th>
                                <th>Hepatite B</th>
                                <th>HPV</th>
                                <th>DST Nº Diag.</th>
                                <th>DST Anos Primeiro Diag.</th>
                                <th>DST Anos Último Diag.</th>
                                <th>Diag. Câncer</th>
                                <th>Diag. CIN</th>
                                <th>Diag. HPV</th>
                                <th>Diag.</th>
                                <th>Hinselmann</th>
                                <th>Schiller</th>
                                <th>Citologia</th>
                                <th>Biópsia</th>
                            </tr>
                    </thead>`;
    var body = `
                <td>${caso.numRelacoes || "?"}</td>
                <td>${caso.primeiraRelacao || "?"}</td>
                <td>${caso.numGestacoes || "?"}</td>
                <td>${retornarResposta(caso.fuma)}</td>
                <td>${caso.numAnosFumo ? caso.numAnosFumo.toFixed(1) : "?"}</td>
                <td>${caso.macosAno ? caso.macosAno.toFixed(1) : "?"}</td>
                <td>${retornarResposta(caso.contraceptivoHormonal)}</td>
                <td>${caso.numAnosContraceptivo ? caso.numAnosContraceptivo.toFixed(1) : "?"}</td>
                <td>${retornarResposta(caso.diu)}</td>
                <td>${caso.numAnosDiu ? caso.numAnosDiu.toFixed(1) : "?"}</td>
                <td>${retornarResposta(caso.dst)}</td>
                <td>${caso.numDst || "?"}</td>
                <td>${retornarResposta(caso.condiloma)}</td>
                <td>${retornarResposta(caso.condilomaUterino)}</td>
                <td>${retornarResposta(caso.condilomaVaginal)}</td>
                <td>${retornarResposta(caso.condilomaVulvoPerineal)}</td>
                <td>${retornarResposta(caso.sifilis)}</td>
                <td>${retornarResposta(caso.inflamacaoPelvica)}</td>
                <td>${retornarResposta(caso.herpesGenital)}</td>
                <td>${retornarResposta(caso.moluscoContagioso)}</td>
                <td>${retornarResposta(caso.aids)}</td>
                <td>${retornarResposta(caso.hiv)}</td>
                <td>${retornarResposta(caso.hepatiteB)}</td>
                <td>${retornarResposta(caso.hpv)}</td>
                <td>${caso.dstNumDiag || "?"}</td>
                <td>${caso.dstPrimeiroDiag ? caso.dstPrimeiroDiag.toFixed(1) : "?"}</td>
                <td>${caso.dstUltimoDiag ? caso.dstUltimoDiag.toFixed(1) : "?"}</td>
                <td>${retornarResposta(caso.cancerDiag)}</td>
                <td>${retornarResposta(caso.cinDiag)}</td>
                <td>${retornarResposta(caso.hpvDiag)}</td>
                <td>${retornarResposta(caso.diagnosticado)}</td>
                <td>${retornarResultado(caso.hinselmann)}</td>
                <td>${retornarResultado(caso.schiller)}</td>
                <td>${retornarResultado(caso.citologia)}</td>
                <td>${retornarResultado(caso.biopsia)}</td>
            `;

    var tabelaConteudo = "<br><div class='table-responsive'><table class='table'>" + head + body + "</table></div>";

    var divCollapse = '<div class="collapse" id="collapse_' + caso.id + '">' + tabelaConteudo + '</div>';
    return divCollapse;
}


$("#casosAdicionados").on("click", ".selecionar", function (e) {
    var id = $(e.currentTarget).data("id");
    $("#casoSelecionado").val(id);
    $("#modalSelecionarCaso").modal("hide");
});

$("#casosAdicionados").on("click", ".collapseButton", function (e) {
    var icone = $(e.currentTarget).children("i");
    if (icone.hasClass("fa-angle-down")) {
        icone.removeClass("fa-angle-down");
        icone.addClass("fa-angle-up");
    } else if (icone.hasClass("fa-angle-up")) {
        icone.removeClass("fa-angle-up");
        icone.addClass("fa-angle-down");
    }
});


function retornarResultado(valor) {
    if (valor == true)
        return "Positivo";
    else if(valor == false)
        return "Negativo";

    return "?";
}

function retornarResposta(valor) {
    if (valor == true)
        return "Sim";
    else if (valor == false)
        return "Não";

    return "?";
}