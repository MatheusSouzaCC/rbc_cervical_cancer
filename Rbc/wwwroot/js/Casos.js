var casosAdicionados = [];

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
                                <th>Idade</th>
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
                                <th>Colposcopia</th>
                                <th>Schiller</th>
                                <th>Citologia</th>
                                <th>Biópsia</th>
                            </tr>
                    </thead>`;
    var body = `
                <td>${caso.idade || "?"}</td>
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

$("#salvarCaso").click(function () {
    var caso = {
        Idade: $("#idade").val(),
        NumRelacoes: $("#numParceiros").val(),
        PrimeiraRelacao: $("#primeiraRelacao").val(),
        NumGestacoes: $("#numGestacoes").val(),
        Fuma: $("#fuma").prop("checked"),
        NumAnosFumo: trocaVirgulaPorPonto($("#fumaAnos").val()),
        NumMacosPorAno: trocaVirgulaPorPonto($("#macosAno").val()),
        ContraceptivoHormonal: $("#contraceptivo").prop("checked"),
        NumAnosContraceptivo: trocaVirgulaPorPonto($("#numAnosContraceptivo").val()),
        Diu: $("#diu").prop("checked"),
        NumAnosDiu: trocaVirgulaPorPonto($("#numAnosDiu").val()),
        Dst: $("#dst").prop("checked"),
        NumDst: trocaVirgulaPorPonto($("#numDst").val()),
        Condiloma: $("#condiloma").prop("checked"),
        CondilomaUterino: $("#condilomaUterino").prop("checked"),
        CondilomaVaginal: $("#condilomaVaginal").prop("checked"),
        CondilomaVulvoPerineal: $("#condilomaVulvoPerineal").prop("checked"),
        Sifilis: $("#sifilis").prop("checked"),
        InflamacaoPelvica: $("#inflamacaoPelvica").prop("checked"),
        HerpesGenital: $("#herpesGenital").prop("checked"),
        MoluscoContagioso: $("#moluscoContagioso").prop("checked"),
        Aids: $("#aids").prop("checked"),
        Hiv: $("#hiv").prop("checked"),
        HepatiteB: $("#hepatiteB").prop("checked"),
        Hpv: $("#hpv").prop("checked"),
        DstNumDiag: trocaVirgulaPorPonto($("#numDst").val()),
        DstAnosPrimeiroDiag: trocaVirgulaPorPonto($("#dstPrimeiro").val()),
        DstAnosUltimoDiag: trocaVirgulaPorPonto($("#dstUltimo").val()),
        CancerDiag: $("#cancerDiag").prop("checked"),
        CinDiag: $("#cinDiag").prop("checked"),
        HpvDiag: $("#hpvDiag").prop("checked"),
        Diagnosticado: $("#diagnosticado").prop("checked"),
        Hinselmann: $("#hinselmann").prop("checked"),
        Schiller: $("#schiller").prop("checked"),
        Citologia: $("#citologia").prop("checked"),
        Biopsia: $("#biopsia").prop("checked"),
        Id: 0
    };
    adicionarCaso(caso);
});


$("#fuma").change(function (e) {
    if ($(e.currentTarget).prop("checked")) {
        $("#fumaAnos").prop("disabled", false);
        $("#macosAno").prop("disabled", false);
    } else {
        $("#fumaAnos").prop("disabled", true);
        $("#fumaAnos").val("");
        $("#macosAno").prop("disabled", true);
        $("#macosAno").val("");
    }
});

$("#contraceptivo").change(function (e) {
    if ($(e.currentTarget).prop("checked")) {
        $("#numAnosContraceptivo").prop("disabled", false);
    } else {
        $("#numAnosContraceptivo").prop("disabled", true);
        $("#numAnosContraceptivo").val("");
    }
});


$("#diu").change(function (e) {
    if ($(e.currentTarget).prop("checked")) {
        $("#numAnosDiu").prop("disabled", false);
    } else {
        $("#numAnosDiu").prop("disabled", true);
        $("#numAnosDiu").val("");
    }
});

$("#dst").change(function (e) {
    if ($(e.currentTarget).prop("checked")) {
        $("#numDst").prop("disabled", false);
    } else {
        $("#numDst").prop("disabled", true);
        $("#numDst").val("");
    }
});

function adicionarCaso(caso) {
    $.ajax({
        url: "/rbc/AdicionarCaso",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(caso),
        success: function (data) {
            $("#modalAdicionarCaso").modal("hide");
            resetarCampos();
            alert("Sucesso: Caso " + data.id + " salvo.");
        },
        error: function (data) {
            alert("Erro: Não foi possível salvar o caso");
        }
    });
}

function resetarCampos() {
    $("#idade").val("");
    $("#numParceiros").val("");
    $("#primeiraRelacao").val("");
    $("#numGestacoes").val("");
    $("#fuma").prop("checked", false);
    $("#fumaAnos").val("");
    $("#macosAno").val("");
    $("#contraceptivo").prop("checked", false);
    $("#numAnosContraceptivo").val("");
    $("#diu").prop("checked", false);
    $("#numAnosDiu").val("");
    $("#dst").prop("checked", false);
    $("#numDst").val("");
    $("#condiloma").prop("checked", false);
    $("#condilomaUterino").prop("checked", false);
    $("#condilomaVaginal").prop("checked", false);
    $("#condilomaVulvoPerineal").prop("checked", false);
    $("#sifilis").prop("checked", false);
    $("#inflamacaoPelvica").prop("checked", false);
    $("#herpesGenital").prop("checked", false);
    $("#moluscoContagioso").prop("checked", false);
    $("#aids").prop("checked", false);
    $("#hiv").prop("checked", false);
    $("#hepatiteB").prop("checked", false);
    $("#hpv").prop("checked", false);
    $("#numDst").val("");
    $("#dstPrimeiro").val("");
    $("#dstUltimo").val("");
    $("#cancerDiag").prop("checked", false);
    $("#cinDiag").prop("checked", false);
    $("#hpvDiag").prop("checked", false);
    $("#diagnosticado").prop("checked", false);
    $("#hinselmann").prop("checked", false);
    $("#schiller").prop("checked", false);
    $("#citologia").prop("checked", false);
    $("#biopsia").prop("checked", false);
}


function retornarResultado(valor) {
    if (valor == true)
        return "Positivo";
    else if (valor == false)
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

function trocaVirgulaPorPonto(num) {
    return parseFloat(num.replace(',', '.'));
}