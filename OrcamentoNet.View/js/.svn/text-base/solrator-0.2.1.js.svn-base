/*
* Solrator v1.0
* Criador webdev
*
*/
if (typeof Solrator == 'undefined') {

    var Solrator = function() {
        var thisClass = this;

        this.init = function(options) {
            defaults = {
                DOMParent: false,
                dominio: '', /* dominio para request */
                canal: '', /* nome do site no FW */
                termos: '', /* +termo para operador AND ; -termo para operador NOT ; termo para sem operador */
                secoes: '', /* separados por virgula */
                secoesEH: '', /* separados por virgula */
                tipoEmpilhamento: 'ultimasNoticias', /* tipo esta associado com o seu template. tipoEmpilhamento=ultimasNoticias pegara o template ultimasNoticias*/
                tipoConteudo: null, /* filtra o tipo de conteÃºdo a ser requisitado: textos, videos ou fotos */
                hasPagination: true, /* TRUE/FALSE para paginacao */
                currentPage: 1, /* pagina corrente */
                limit: 5, /* quantidade de itens a serem exibidos */
                showPages: 10, /* quantas paginas devem aparecer */

                objectsToPopulate: {
                    container: $('#solrator'), /* objeto que guardara o html dos itens */
                    pagination: $('div#pagination') /* objeto que guardara o html da paginacao */
                },

                templates: {
                    items: {
                        paginaDeEmpilhamento: '<li>'
												    + '[[thumbnailHTML]]'
												    + '<div class="right">'
												    	+ '<cite class="data" style="display:block;">[[startDate]]</cite>'
												    	+ '<h5><a href="[[url]]" title="[[titulo]]">[[titulo]]</a></h5>'
												    	+ '<p><a href="[[url]]" title="[[titulo]]">[[olho]]</a></p>'
												    + '</div>'
												    + '<div class="clear"></div>'
											    + '</li>',

                        ultimasNoticias: '<li class="[[zebra]]">'
												+ '[[thumbnailHTML]]'
												+ '<div class="right">'
													+ '<cite style="display:block;" class="data">[[startDate]]</cite>'
													+ '<h5>' + '<a href="[[url]]" title="[[titulo]]">[[titulo]]</a>' + '</h5>'
												+ '</div>'
												+ '<div class="clear"></div>'
											+ '</li>',

                        video: '<li class="[[zebra]]">'
									+ '<a class="thumb" href="[[url]]">'
										+ '<img height="83" width="148" alt="[[titulo]]" src="[[urlImgEmp_288x192]]">'
										+ '<span class="duracao"></span>'
									+ '</a>'
									+ '<div>'
										+ '<cite class="data">[[startDate]]</cite>'
										+ '<h5>'
											+ '<a title="[[titulo]]" href="[[url]]">[[titulo]]</a>'
										+ '</h5>'
										+ '<p>[[olho]]</p>'
									+ '</div>'
									+ '<div class="clear"></div>'
								+ '</li>',

                        galeria: '<li class="pdr">'
										+ '<div>'
											+ '<a title="[[titulo]]" href="[[url]]">'
												+ '<img width="204" height="153" alt="[[titulo]]" src="[[urlImgEmp_204x153]]">'
											+ '</a>'
											+ '<cite class="data">[[startDate]]</cite>'
											+ '<h4>'
												+ '<a title="[[titulo]]" href="[[url]]">[[titulo]]</a>'
											+ '</h4>' + '<div class="clear"></div>'
										+ '</div>'
										+ '<div class="clear"></div>'
									+ '</li>',
                        enquete: '<li class="pdr">'
										+ '<div>'
											+ '<a title="[[titulo]]" href="[[url]]">'
												+ '<img width="204" height="153" alt="[[titulo]]" src="[[urlImgEmp_204x153]]">'
											+ '</a>'
											+ '<cite class="data">[[startDate]]</cite>'
											+ '<h4>'
												+ '<a title="[[titulo]]" href="[[url]]">[[titulo]]</a>'
											+ '</h4>' + '<div class="clear"></div>'
										+ '</div>'
										+ '<div class="clear"></div>'
									+ '</li>',
                        custom: '<li class="[[zebra]]">'
								+ '<p>[[titulo]]</p>' + '</li>'
                    },
                    pagination: {
                        previous: '<li class="nav"><a href="#' + options.instanceID + '" data-page="[[PAGE_NUM]]" data-instance="[[INSTANCE_ID]]" class="anterior">Anterior</a></li>',
                        next: '<li class="nav"><a href="#' + options.instanceID + '" data-page="[[PAGE_NUM]]" data-instance="[[INSTANCE_ID]]" class="proxima">PrÃ³xima</a></li>',
                        loop: '<li><a href="#' + options.instanceID + '" data-page="[[PAGE_NUM]]" data-instance="[[INSTANCE_ID]]" class="page">[[PAGE_NUM]]</a></li>',
                        active: '<li class="selected"><span>[[PAGE_NUM]]</span></li>'
                    }
                },
                beforeRender: function(data) {
                    /*
                    * @param data **required** @return data **required**
                    * 
                    * funcao executada apos response do request ajax serve para
                    * manipular a resposta do ajax
                    */
                    return data;
                },
                afterRender: function(html) {
                    /*
                    * @param html **required** @return html **required**
                    * 
                    * funcao executada apos a aplicacao do template recebe o
                    * html que sera escrito
                    */
                    return html;
                },
                beforeRenderItem: function(i, item) {

                    /*
                    * @param i **required** @param item **required** @return
                    * item **required**
                    * 
                    * funcao executada antes de renderizar cada iteracao dos
                    * resultados da busca serve para fazer manipulacao no item
                    * corrente e retornar para o template de forma modificada
                    * 
                    * Ex: if(thisClass.options.tipoEmpilhamento == 'video'){
                    * item.thumbnailHTML = '<img
                    * src="http://lorempixum.com/g/80/80" alt="" />'; }
                    * 
                    * return item;
                    */

                    return item;

                },
                afterRenderItem: function(i, html) {

                    /*
                    * @param i **required** @param html **required** @return
                    * html **required**
                    * 
                    * funcao executada apos a aplicacao do item no template
                    * recebe o indice do item corrente recebe o html do item
                    * corrente
                    * 
                    */

                    return html;
                },
                callback: function() {

                    /*
                    * @return void
                    * 
                    * funcao executada apos o carregamento de todos os
                    * elementos DOM da pagina
                    * 
                    */
                }

            }

            thisClass = window[options.instanceID];
            thisClass.options = $.extend({}, defaults, options);

        }

        /*
        * Responsavel pela montagem do html e interacao dos links para
        * paginacao @return void
        */
        this.paginator = function() {
            thisClass.options.objectsToPopulate.pagination.html('');
            var html = "",
				page = thisClass.options.currentPage,
				totalPages = thisClass.options.totalPages,
				showPages = thisClass.options.showPages;

            if (parseInt(totalPages) <= 1)
                return false;

            // PREVIOUS PAGE, if exist
            if (page > 1) {
                html += thisClass.options.templates.pagination.previous.replace(/\[\[PAGE_NUM\]\]/gi, page - 1).replace(/\[\[INSTANCE_ID\]\]/gi, thisClass.options.instanceID);
            }

            // 3 pages before actual, 7 pages in total
            var cont = page - showPages / 2 <= 0 ? 1 : parseInt(page - showPages / 2);
            var len = cont + showPages <= totalPages ? cont + showPages : totalPages;

            while (cont <= len) {
                var template = thisClass.options.templates.pagination.loop;

                if (cont == page) {
                    template = thisClass.options.templates.pagination.active;
                }

                html += template.replace(/\[\[PAGE_NUM\]\]/gi, cont).replace(/\[\[INSTANCE_ID\]\]/gi, thisClass.options.instanceID);

                cont++;
            }
            // NEXT PAGE, if exist
            if (page < totalPages) {
                html += thisClass.options.templates.pagination.next.replace(/\[\[PAGE_NUM\]\]/gi, page + 1).replace(/\[\[INSTANCE_ID\]\]/gi, thisClass.options.instanceID);
            }

            thisClass.options.objectsToPopulate.pagination.html(html);

            thisClass.options.objectsToPopulate.pagination.find('a').click(function() {

                window[$(this).attr('data-instance')].empilha({
                    'currentPage': parseInt($(this).attr('data-page'))
                });

                $(window).scrollTop(0);
            })
        }

        /*
        * Responsavel por montar a url no padrao do solr
        * http://dominio.ig.com.br/_indice/noticias/select?start=3&size=3&site=arena&secoes=123123123123123
        * 1231231123 123123123&comb_termos="ps3"+"psp"-"iOS"&wt=json @return
        * String url
        */
        this.montaURL = function() {

            var start = (thisClass.options.currentPage - 1) * thisClass.options.limit,
				limit = thisClass.options.limit,
				dominio = thisClass.options.dominio,
				canal = thisClass.options.canal,
				termos = thisClass.options.termos,
				secoes = thisClass.options.secoes,
				secoesEH = thisClass.options.secoesEH,
				tipoConteudo = thisClass.options.tipoConteudo
            dataType = 'json';

            /*
            * Ex: (String) termos = '+PS3,+PSP,-SONY'; Busca todas as noticias
            * com PS3 e PSP que nao tenham a palavra-chave SONY +termo = AND
            * operator in solr -termo = NOT operator in solr termo = NOT
            * operator in solr
            */
            var termosSplit =
				termos.split(','),
				termosStr = '';

            for (termo in termosSplit) {

                termo = termosSplit[termo];
                if (/^\-/.test(termo)) {
                    termosStr += '-' + '"' + termo.replace(/^-/, '') + '"';
                } else if (/^\+/.test(termo)) {
                    termosStr += '+' + '"' + termo.replace(/^\+/, '') + '"';
                } else {
                    termosStr += '"' + termo.replace(/^[\+-]/, '') + '"';
                }

            }
            /* removendo o primeiro + ou - da string de busca dos termos */
            termosStr = termosStr.replace(/^[\+-]/, "")

            /*
            * ids das secoes do fw
            * 
            */
            var secoesSplit = secoes.split(','),
				secoesStr = secoesSplit.join(" ");

            /*
            * ids das secoes do eh
            * 
            */
            var secoesEHSplit = secoesEH.split(','),
				secoesEHStr = secoesEHSplit.join(" ");

            var url = 'http://' + dominio + '/';
            url += '_indice/noticias/select?';
            url += 'start=' + start;
            url += '&size=' + limit;
            url += '&site=' + canal;

            /* veririca a existencia de secoes */
            if (secoesStr.replace(/\s*/g, '').length > 0) {
                url += '&secoes=' + secoesStr;
            }

            /* veririca a existencia de secoes */
            if (secoesEHStr.replace(/\s*/g, '').length > 0) {
                url += '&secoes_eh=' + secoesEHStr;
            }

            /* veririca a existencia de termos */
            if (termosStr.replace(/["\+-]*/g, '').length > 0) {
                url += '&comb_termos=' + termosStr;
            }

            /* veririca a existencia de filtro por tipo de conteÃºdo */
            if (tipoConteudo && tipoConteudo.replace(/["\+-]*/g, '').length > 0) {
                url += '&tipoConteudo=' + tipoConteudo;
            }

            url += '&wt=json';

            // replace para tratamento do '+' para %2B do solr
            return encodeURI(url).replace(/"\+"/g, '"%2B"');

        }

        /*
        * Responsavel pelos requests e aplicacao de filtros de
        * before/afterRender @return void
        * 
        */
        this.empilha = function(options) {

            thisClass.options = $.extend({}, thisClass.options, options);

            url = thisClass.montaURL();

            /*
            * heranca para as funcoes filhas disparadas, sem isso da pau com
            * multiplas instancias
            */
            var superClass = thisClass;

            $.ajax({
                url: url,
                dataType: 'json',
                success: function(data) {

                    /*
                    * normalizacao das herancas para as funcoes filhas
                    * e suporte a multiplas instancias
                    */
                    thisClass = superClass;

                    /* total de paginas */
                    thisClass.options.totalPages = Math.ceil(data.response.numFound / thisClass.options.limit);

                    /*
                    * execucao do filtro de renderizacao do response do
                    * ajax
                    */
                    if (!(typeof thisClass.options.beforeRender == 'undefined')) {
                        data = thisClass.options.beforeRender(data);
                    }

                    var strItems = '';
                    // Percorre resultados do objeto
                    $.each(data.response.docs, function(i, item) {

                        item.url = "http://" + item.url.replace("http://", "");

                        /* pretatamento de imagem para empilhamentos */
                        if (typeof item.urlImgEmp_112x84 != "undefined") {
                            item.thumbnailHTML = '<a href="' + item.url + '" title="' + item.titulo + '" class="thumb"><img width="111" height="83" src="' + item.urlImgEmp_112x84 + '" alt="' + item.titulo.replace(/"/g, "") + '" /></a>';
                        } else if (typeof item.urlImgEmp_204x153 != "undefined") {
                            item.thumbnailHTML = '<a href="' + item.url + '" title="' + item.titulo + '" class="thumb"><img width="111" height="83" src="' + item.urlImgEmp_204x153 + '" alt="' + item.titulo.replace(/"/g, "") + '" /></a>';
                        } else {
                            item.thumbnailHTML = '';
                        }

                        item.startDate = SolrUtils.solr_formatar_data(item.startDate);

                        /* execucao do filtro de item */
                        if (!(typeof thisClass.options.beforeRenderItem == 'undefined')) {
                            item = thisClass.options.beforeRenderItem(i, item);
                        }

                        /*
                        * string temporaria para
                        * manipulacao do template
                        */
                        var tempStr = thisClass.options.templates.items[thisClass.options.tipoEmpilhamento];

                        /* tratamento para a zebra */
                        if (i % 2 == 0) {
                            tempStr = thisClass.options.templates.items[thisClass.options.tipoEmpilhamento]
									.replace('[[zebra]]', 'odd');
                        } else {
                            tempStr = thisClass.options.templates.items[thisClass.options.tipoEmpilhamento]
									.replace('[[zebra]]', 'alt');
                        }

                        // Busca todas as variaveis,
                        // [[var]], setadas no template
                        var searchVars = new RegExp(/\[\[.*?\]\]/g), getVars = tempStr.match(searchVars);

                        // Percorre vars do template
                        for (var a = 0; a < getVars.length; a++) {

                            // Pega o nome da variavel
                            // setada no template
                            var columnName = getVars[a].replace('[[', '').replace(']]', '');

                            // Se existe a var no objeto
                            // retornado, realiza o
                            // replace
                            // Black magic, dont touch
                            // this.
                            if (item[columnName] != undefined) {
                                tempStr = tempStr.replace(new RegExp('\\[\\[' + columnName + '\\]\\]', 'g'), item[columnName]);
                            } else {
                                tempStr = tempStr.replace(new RegExp('\\[\\[' + columnName + '\\]\\]', 'g'), '');
                            }
                        }

                        if (thisClass.options.tipoEmpilhamento == "galeria") {
                            if ((i + 1) % 3 == 0) {
                                tempStr = tempStr.replace("pdr", "nopdr");
                            }
                        }

                        /*
                        * execucao do filtro de pos
                        * renderizacao do item
                        */
                        if (!(typeof thisClass.options.afterRenderItem == 'undefined')) {
                            tempStr = thisClass.options.afterRenderItem(i, tempStr);
                        }

                        strItems += tempStr;

                    })

                    /* paginacao */
                    if (thisClass.options.hasPagination) {
                        /* Paginator */
                        thisClass.paginator();
                    }

                    /*
                    * execucao do filtro de pos renderizacao do
                    * container todo
                    */
                    if (!(typeof thisClass.options.afterRender == 'undefined')) {
                        strItems = thisClass.options.afterRender(strItems);
                    }

                    /* Populate */
                    thisClass.options.objectsToPopulate.container.html(strItems);

                    /* callback apos feito tudo */
                    if (!(typeof thisClass.options.callback == 'undefined')) {
                        thisClass.options.callback();
                    }
                }
            });
        }

    }
} // if not defined

if (typeof SolrUtils == "undefined") {

    var SolrUtils = {

        zero_pad: function(num) {
            if (num < 10)
                num = '0' + num;

            return num;
        },
        solr_formatar_data: function(data) {
            var ext = /^(\d+)-(\d+)-(\d+)T(\d+):(\d+):(\d+)Z$/.exec(data);
            var utc = new Date();
            utc.setUTCFullYear(ext[1]);
            utc.setUTCMonth(parseInt(ext[2], 10) - 1);
            utc.setUTCDate(ext[3]);
            utc.setUTCHours(ext[4]);
            utc.setUTCMinutes(ext[5]);

            var mon = this.zero_pad(parseInt(utc.getMonth(), 10) + 1);
            var day = this.zero_pad(utc.getDate());
            var hour = this.zero_pad(utc.getHours());
            var min = this.zero_pad(utc.getMinutes());
            var year = utc.getFullYear();

            return hour + ":" + min + " | " + day + "/" + mon + "/" + year;
        }

    }
}

