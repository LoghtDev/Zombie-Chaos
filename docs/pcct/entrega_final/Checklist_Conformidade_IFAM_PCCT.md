# Checklist de conformidade institucional — PCCT Zombie Chaos

A verificação combina a leitura do DOCX e do PPTX, a inspeção dos estilos, dimensões, campos e imagens incorporadas, e a conferência visual dos PDFs exportados. A coluna de resultado se aplica à exigência específica registrada em cada linha.

| Item | Exigência | Resultado | Observações verificadas |
|---|---|---|---|
| Base do relatório | DOCX institucional como documento-base | Conforme | Partiu de `Modelo_Relatório_Técnico_Cientifico_PCCT_1.docx`. As quatro seções foram mantidas. |
| Papel | A4, 21 × 29,7 cm | Conforme | Largura e altura verificadas nas quatro seções do DOCX e no PDF exportado. |
| Margens | Superior e esquerda 3 cm, inferior e direita 2 cm | Conforme | Valores conferidos nas quatro seções do relatório e no roteiro. |
| Fonte do corpo editável | Times New Roman 12 pt | Conforme | Estilo de corpo e títulos inspecionados. As exceções de capa e folha de rosto do modelo foram mantidas. Legendas, tabelas e código usam estilos próprios. |
| Espaçamento, alinhamento e recuo | 1,5 linha, justificado e primeira linha de 1,25 cm | Conforme | Propriedades verificadas no estilo Corpo PCCT. Capa, listas, legendas, tabelas e referências seguem formatação própria. |
| Capa e folha de rosto | Identidade, local, ano, curso, equipe, natureza do PCCT e orientação | Conforme | Imagem oficial da capa confere byte a byte com o modelo. Manacapuru consta no local. Nome do orientador confirmado nos créditos do jogo. Titulação e coorientação não foram presumidas. |
| Pré-textuais | Resumo, palavras-chave, listas pertinentes e sumário | Conforme | Capa, folha de rosto, resumo, listas e sumário antecedem o texto. |
| Ficha catalográfica e verso da folha de rosto | Inserção quando aplicável à turma | Pendente | Confirmar exigência com a coordenação ou biblioteca. Nenhum dado catalográfico foi fabricado. |
| Estrutura | Sete capítulos numerados | Conforme | Introdução, Referencial Teórico, Metodologia, Resultados, Discussão dos Resultados, Considerações Finais e Referências. Os títulos usam estilos de cabeçalho do Word. |
| Extensão textual | Pelo menos 25 páginas de elementos textuais | Conforme | 39 páginas físicas, das quais **32 textuais**. A contagem usa as páginas físicas 6–37, da Introdução ao fim das Considerações Finais. Exclui cinco páginas pré-textuais e duas de Referências. |
| Sumário e paginação | Campos atualizáveis com destinos e números reais, numeração visível a partir do texto | Conforme | Sumário com campo TOC, 41 entradas vinculadas e referências de página conferidas contra o PDF. A folha de rosto inicia a contagem e a exibição começa na Introdução, com número 5. |
| Figuras e código | Figuras numeradas, legenda acima e fonte abaixo, trechos reais | Conforme | Onze figuras com título, imagem e fonte na mesma página. Oito recortes C# mantidos com identificação de arquivo e linhas. |
| Tabelas | Identificação e continuidade das tabelas | Conforme | Onze tabelas numeradas no corpo e um quadro de siglas. Cabeçalhos repetidos nas continuações e linhas impedidas de dividir entre páginas. |
| Citações e referências | Sistema consistente e validação normativa aplicável | Pendente | Usado autor-data, com referências vinculadas às fontes técnicas. As versões vigentes e os detalhes do Manual e das NBR de trabalhos acadêmicos, relatórios, citações, referências, resumo, numeração e sumário não puderam ser confrontados com as fontes oficiais. |
| Base do PowerPoint | Modelo do Campus Manacapuru fornecido pelo orientador | Conforme | Partiu de `MODELODESLIDESPARAAPRESENTAOEMPOWERPOINT - Walter.pptx`. Os arquivos de fundo usados nos 17 slides e a logomarca da capa foram comparados aos do modelo. |
| Dimensões dos slides | 4:3, 10 × 7,5 pol. | Conforme | 9.144.000 × 6.858.000 EMU, iguais aos valores do original editável. |
| Fontes e tamanho nos slides editáveis | Arial nos títulos, Calibri no corpo e corpo mínimo de 16 pt | Conforme | Títulos em Arial. Usam 32 pt nos slides internos, 29 pt no título largo da HDRP e 24 pt no título oficial da capa. Todos os textos visíveis do corpo foram conferidos em Calibri, com tamanho igual ou superior a 16 pt. |
| Composição institucional | Faixas verdes e cinzas, fundo branco interno e capa e encerramento institucionais | Conforme | Capa, slides internos e encerramento inspecionados em PDF. Texto de conteúdo ficou na área útil, e os títulos na faixa superior. |
| Exportação com as fontes Microsoft originais | Times New Roman, Arial e Calibri na renderização | Pendente | Os editáveis declaram as fontes exigidas. Os PDFs desta entrega usam os equivalentes métricos disponíveis no ambiente: Liberation Serif, Liberation Sans e Carlito. Para exigir as fontes originais no PDF, exportar com as fontes Microsoft instaladas e conferir novamente a paginação. |
| Duração programada | 17 slides somando 15 minutos | Conforme | Intervalos no PPTX somam 900 segundos. O bloco final de demonstração reserva 50 segundos dentro do slide 16. |
| Duração em apresentação oral | Fala, transições e demonstração em 15 minutos | Pendente | Roteiro e notas sincronizados. As falas dos slides sem demonstração foram dimensionadas para cerca de 99 a 139 palavras por minuto, incluindo transições faladas. A duração real requer ensaio no equipamento da banca. |
| Roteiro | Capa simplificada, Times New Roman 12, margens e 17 falas sincronizadas | Conforme | Logo oficial preservado, estilos reais de texto e títulos, divisão de apresentadores, tempos, ações visuais, transições e perguntas. PDF com 23 páginas. |
| Registro visual de execução | Capturas reais e vídeo da demonstração | Pendente | Foram usadas imagens de recursos e renderizações dos FBX reais, identificadas como externas. Os mapas HDRP/Lit do Zombie foram acrescentados. As capturas de Graphics/Quality, luzes, Volumes, material no Inspector e a comparação controlada continuam no guia. |
| Revisão visual | Todas as páginas e todos os slides renderizados e inspecionados | Conforme | Revisadas 39 páginas do relatório, 17 slides e 23 páginas do roteiro. Também foram conferidos limites de texto, links do sumário e artefatos editáveis. |

## Validação complementar da HDRP

- Título oficial aplicado ao relatório, à capa dos slides e à capa do roteiro.
- As configurações de Graphics, Quality, HDRP Assets e Global Settings foram confrontadas com as cenas, os Volumes, as câmeras, o material do Zombie e o script de feedback de dano.
- A documentação e o código oficiais da Unity foram consultados pelo repositório Unity Graphics, linha 6000.0. A versão instalada de HDRP 17.0.3 foi estabelecida pelos arquivos do projeto.
- O slide 11 tem 1:40. Os temas previamente aprovados foram mantidos e os tempos foram redistribuídos para 15:00, incluindo a demonstração.
- O roteiro tem 31 perguntas de banca, sendo 16 sobre renderização e a separação da física. Comparações de desempenho e capturas em runtime permanecem pendentes.

## Fontes institucionais e limites

Os dois modelos editáveis anexados foram a referência primária. O acesso nesta sessão ao Manual de TCC do IFAM, à página de identidade do Campus Manacapuru e ao catálogo ABNT recebeu HTTP 403. A exigência de 25 páginas foi aplicada conforme a seção 5.3.2 informada na solicitação. A aprovação formal da coordenação e a verificação dos requisitos normativos que dependem de consulta externa ficam pendentes.

- [Manual de TCC do IFAM](https://www2.ifam.edu.br/pro-reitorias/ensino/proen/biblioteca/noticias-1/manual-do-trabalho-de-conclusao-de-curso-do-ifam/)
- [Identidade visual do Campus Manacapuru](https://www2.ifam.edu.br/campus/manacapuru/publicacoes/identidade-visual)
- [Catálogo ABNT](https://www.abntcatalogo.com.br/)
