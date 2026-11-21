# Guia de capturas — Zombie Chaos

As áreas marcadas como captura pendente já têm espaço na apresentação. Envie as capturas abaixo para completar o registro visual em Unity e a demonstração. As imagens dos inimigos são renderizações externas dos FBX do repositório. Para o registro acadêmico, use as capturas da build ou do Unity listadas abaixo e indique cena, revisão e origem nas legendas.

| ID | Cena ou arquivo | O que capturar | Destino |
|---|---|---|---|
| C01 | `Assets/Cenas/MenuPrincipal.unity` | Menu com título, Jogar, Configurações e Sair. Capture em Game View ou build | Relatório §4.14 ou slide 2 |
| C02 | `MenuPrincipal` → Configurações → Créditos | Configurações antes de abrir o painel e tela de créditos com funções legíveis | Slide 13 e relatório §4.14 |
| C03 | `Assets/Cenas/Game.unity` | Visão de uma via com obstáculo e zona de compra. Fazer também uma imagem de HUD em combate | Slides 10 e 13 e relatório §4.14 |
| C04 | `Game` → loja e pausa | Mostrar F perto da área, cartões e menu de pausa em imagens separadas | Slide 13 ou relatório §4.14 |
| C05 | `Game` → Game Over | Registrar onda e abates depois da derrota | Relatório §4.14 |
| C06 | `Assets/Prefabs/Zombie.prefab` | Prefab Mode e Inspector de `neck_01`, `spine_02` e do filho `Hitbox`. Mostrar a caixa Is Trigger em estado correspondente | Slide 8 como foto de apoio, mantendo o diagrama |
| C07 | `Game.unity` → NavMesh Surface | Scene View com malha visível e obstáculos. Identificar o tipo do agente escolhido | Slide 9 ou relatório §4.8 |
| C08 | Build Windows, cena `Game` | Vídeo de 50 s, com movimento, mira, disparo, HUD e loja. Revisão e áudio verificados | Slide 16. Reserva offline |

## Como substituir sem refazer o slide

1. Capture em boa resolução. Para o PowerPoint institucional de 10 × 7,5 pol., componha cada recorte dentro da área branca e preserve a proporção da imagem. Evite informações pessoais e barras de ferramentas dispensáveis.
2. Abra o PPTX e selecione os elementos do quadro de captura pendente. Anote a área ou use as linhas-guia. Insira a imagem e recorte proporcionalmente.
3. Para o slide 13, use uma captura em cada área marcada. Mantenha as faixas institucionais e a logomarca livres. Para o slide 8, preserve as relações entre raiz, regiões receptoras e trigger.
4. Substitua o texto de captura pendente por uma legenda curta, por exemplo “Arena em execução · Game.unity · revisão d5c554a”. Indique a revisão realmente capturada.
5. No relatório Word, insira as imagens na seção correspondente de Resultados (por exemplo, §4.14), atualize numeração, lista de figuras e sumário e reexporte o PDF.

## Demonstração offline

Abra a build antes da defesa e deixe a sessão ou o menu preparados. Registre uma alternativa local em MP4 e mantenha os arquivos no mesmo computador. No slide 16, use **00–08 s** para a introdução, **08–20 s** para mover e mirar, **20–35 s** para combate, **35–48 s** para chegar à loja e **48–58 s** para mostrar o saldo e os cartões. Use **58–70 s** para a síntese e a transição. A demonstração cabe no bloco mesmo se o abate não ocorrer. Mostre o consumo de munição e avance para a loja. Reexporte a apresentação em PDF depois de trocar as imagens.

## Coleção de evidências HDRP

Os quatro mapas no slide 11 são recursos originais ligados ao material do Zombie. Eles documentam a entrada do shader. As capturas seguintes devem vir do Inspector, da Game View ou de uma build identificada.

| ID | Onde capturar | Evidência de interesse | Destino |
|---|---|---|---|
| C09 | Edit → Project Settings → Graphics e Quality | Asset HDRP de fallback, Global Settings e ligação Baixo/Médio/Alto a Performant, Balanced e High Fidelity | Relatório §4.13; apoio ao slide 5 ou 11 |
| C10 | `Assets/Cenas/Game.unity` → Directional Light e Game View | Temperatura habilitada, sombra suave e objeto iluminado no enquadramento | Slide 10 ou 11; relatório §4.13 |
| C11 | `ZombieBB_Body_HDRP.mat` no Inspector | Shader HDRP/Lit e os slots Base Color, Normal, Mask Map e Emission. Mostrar o material realmente atribuído no prefab Zombie | Slide 11; relatório §4.13 |
| C12 | `Volume Menu.asset`, `Global Volume Profile.asset` e `DanoVolume Profile.asset` | Overrides de Fog, Exposure e Bloom. Mostrar também o Volume de dano em Game, com peso inicial 0 e prioridade 1 | Slide 11 ou relatório §4.13 |
| C13 | Game View ou build `Game` | Quadro representativo com geometria iluminada, silhueta e profundidade da arena. Anotar nível, API e resolução | Slides 10, 11 ou 12 |
| C14 | Mesmo quadro nos níveis Baixo, Médio e Alto, quando possível | Renderizações legítimas, com câmera, resolução, cena, API e estado fixos. Anotar o perfil e capturar após estabilizar a exposição | Comparação opcional no relatório §5.4 ou apoio ao slide 15 |

Para C14, os níveis alteram várias opções. Apresente o comparativo como efeito do **perfil completo**. Se o objetivo for isolar a neblina, varie apenas esse parâmetro em uma cópia de teste e mantenha as demais condições iguais. A coleção não depende de uma migração para URP. Se não houver capturas a tempo, mantenha os mapas e as configurações auditadas no slide 11.
