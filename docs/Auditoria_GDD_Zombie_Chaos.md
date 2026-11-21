# Auditoria técnica e de design do GDD — Zombie Chaos

**IFAM — Campus Manacapuru · PCCT · 20 de novembro de 2026**  
**Linha de base:** [`LoghtDev/Zombie-Chaos`, `main` em `d5c554a02181d6a6082818a5be659acf51059df9`](https://github.com/LoghtDev/Zombie-Chaos/tree/d5c554a02181d6a6082818a5be659acf51059df9).  
**Escopo:** documentação e leitura dos recursos versionados.

## 1. Método e limites

A raiz Unity é a que contém `Assets`, `Packages` e `ProjectSettings`. Foi usada a revisão da `main` remota, que inclui as alterações de créditos feitas após a branch `creditos`. A equipe e as funções foram conferidas no texto serializado efetivo dessa revisão. O inventário encontrou 22 cenas, duas habilitadas em build, e 18 scripts autorais em `Assets/Scripts`. Código e recursos de fornecedores foram examinados onde contribuem para o fluxo de jogo ou para delimitar demonstrações externas.

A leitura cruzou as configurações Unity, o manifesto, o lockfile, os scripts C#, os blocos de objetos e componentes nas cenas, as sobrescritas de prefab, referências por GUID em arquivos `.meta`, os eventos persistentes, os metadados de animação e os recursos de áudio e arte vinculados. Uma referência serializada demonstra intenção e ligação estática. Sua execução precisa ser verificada em Play Mode ou build. O modelo IFAM determinou a cobertura obrigatória. O GDD antigo serviu à apresentação e à identificação de divergências, sem autoridade sobre a implementação.

Na preparação anterior do ambiente, o editor 6000.0.35f1 foi instalado e encerrou a tentativa batch com `No valid Unity Editor license found`. A presente auditoria não executou a build da revisão nem realizou playtests, profiling ou medições. O relato externo confirma que um executável abriu após uma espera, e o log fornecido identifica inicialização do Direct3D 11. Não há associação comprovada entre esse binário e o commit auditado, nem cronometração ou cobertura de partida.

## 2. Matriz de evidências e estados

**Implementado** significa implementação integrada identificada estaticamente. **Parcialmente implementado** identifica caso incompleto ou incoerente. **Planejado** exige evidência de intenção com escopo definido. **Não confirmado** indica ausência de evidência confiável para a afirmação. Uma proposta desta auditoria não é tratada como planejamento aprovado do jogo.

| Sistema | Estado | Evidência e interpretação |
|---|---|---|
| Bootstrap da build | Implementado | [EditorBuildSettings.asset](../ProjectSettings/EditorBuildSettings.asset) habilita [MenuPrincipal.unity](../Assets/Cenas/MenuPrincipal.unity) em 0 e [Game.unity](../Assets/Cenas/Game.unity) em 1. Os eventos de Jogar e Finalizar carregam esses índices e o script repõe a escala de tempo. |
| Versão e tecnologias | Implementado | [ProjectVersion.txt](../ProjectSettings/ProjectVersion.txt), [manifest.json](../Packages/manifest.json), [packages-lock.json](../Packages/packages-lock.json), [GraphicsSettings.asset](../ProjectSettings/GraphicsSettings.asset) e [QualitySettings.asset](../ProjectSettings/QualitySettings.asset) identificam editor, versões e pipeline efetivo. Pacotes presentes não comprovam uso em runtime. |
| Movimento e câmera | Implementado | [MovimentoJogador.cs](../Assets/Scripts/MovimentoJogador.cs), [InputManager.asset](../ProjectSettings/InputManager.asset) e `Game.unity` demonstram CharacterController, verificação de chão, stamina, passos e Cinemachine nos eixos legados. A drenagem pode ocorrer enquanto Shift está pressionado sem movimento. |
| Touch e gamepad completo | Parcialmente implementado para gamepad; touch não confirmado | [ProjectSettings.asset](../ProjectSettings/ProjectSettings.asset) permite ambos os sistemas de entrada e [InputSystem_Actions.inputactions](../Assets/InputSystem_Actions.inputactions) existe. Os eixos e Fire1 têm associação legada de joystick, mas faltam ligações completas no loop. Não há UI de joystick virtual nas cenas do build. |
| Armas e acertos | Implementado | [GerenciadorDeArmas.cs](../Assets/Scripts/GerenciadorDeArmas.cs), [Arma.cs](../Assets/Scripts/Arma.cs), [ParteDoCorpo.cs](../Assets/Scripts/ParteDoCorpo.cs) e os seis componentes em `Game.unity` comprovam uma única consulta de raycast por disparo, níveis de dano, limiar de distância e feedback. |
| Animação e FX do arsenal | Implementado | [ArmaSway.cs](../Assets/Scripts/ArmaSway.cs), [Recarregar.cs](../Assets/Scripts/Recarregar.cs), [ArmaOffset.controller](../Assets/Animacoes/Controllers/ArmaOffset.controller), [Pistola.controller](../Assets/Animacoes/Controllers/Pistola.controller), `Assets/Modelos 3D/Pistola/source/arms@beretta.fbx.meta` e `Assets/Prefabs/FX` sustentam balanço, troca, sons e efeitos. |
| Munição e HUD na troca | Parcialmente implementado | Em `GerenciadorDeArmas.cs`, `ExecutarRecarga` usa `min(capacidade, reserva) − atual`. Com 5 no carregador e 3 na reserva, uma arma comum obteria −2 unidades para a recarga. Em `AlterarArma`, a chamada final atualiza a interface com `armaAtual`, a referência anterior. São consequências do código, não casos executados. |
| Vida e pontuação | Implementado | [Jogador.cs](../Assets/Scripts/Jogador.cs), [VidaInimigo.cs](../Assets/Scripts/VidaInimigo.cs) e `Game.unity`. Vida inicial 100, saldo 5.000. Dano letal gera `OnMorrer`, a recompensa é creditada no chamador e o dano alto no disparo fatal dobra os pontos. |
| Ondas e spawns | Implementado | [GeradorDeMonstros.cs](../Assets/Scripts/GeradorDeMonstros.cs) e lista em `Game.unity`. São 49 entradas de spawn e 5 prefabs. O avanço é temporal e a vida se recupera. O total por sub-onda sofre divisão inteira. Se não existir spawn a pelo menos 15 unidades, a tentativa aleatória não tem saída no código. A ocorrência no mapa corrente não foi testada. |
| Navegação e corpo a corpo | Implementado | [Inimigo.cs](../Assets/Scripts/Inimigo.cs), [HitboxInimigo.cs](../Assets/Scripts/HitboxInimigo.cs), [Zombie.prefab](../Assets/Prefabs/Zombie.prefab), [ZombieMutante.prefab](../Assets/Prefabs/ZombieMutante.prefab), [Aranha.prefab](../Assets/Prefabs/Aranha.prefab), [Lobisomem.prefab](../Assets/Prefabs/Lobisomem.prefab), `Assets/Cenas/Game/NavMesh-NavMesh Surface.asset` e `Assets/Cenas/Game/NavMesh-NavMesh Surface (1).asset`. A dimensão do ataque usa lógica temporal, trigger do jogador e eventos de animação. A cobertura de rotas e a chamada de evento de cada variante exigem teste. |
| Ataque à distância | Implementado | [InimigoViador.cs](../Assets/Scripts/InimigoViador.cs), [BolaAcida.cs](../Assets/Scripts/BolaAcida.cs), [Migo.prefab](../Assets/Prefabs/Migo.prefab) e [BolaAcida.prefab](../Assets/Prefabs/BolaAcida.prefab). O componente ConstantForce do prefab aplica força local de 8 no eixo Z. O script mata o colisor após o contato e agenda remoção. O descarte quando erra não está explicitamente tratado pelo script. |
| Loja | Implementado | [GerenciadorLoja.cs](../Assets/Scripts/GerenciadorLoja.cs), [ArmaCard.cs](../Assets/Scripts/ArmaCard.cs), [AreaDeCompra.prefab](../Assets/Prefabs/AreaDeCompra.prefab), [ArmaCard.prefab](../Assets/Prefabs/ArmaCard.prefab) e sobrescritas de preços na arena. Compra de arma troca o slot secundário. Compra de munição enche a reserva. A lógica não discrimina reserva cheia ou item já equipado. |
| Opções e gestão de estado | Implementado | [MenuConfiguracoes.cs](../Assets/Scripts/MenuConfiguracoes.cs), `Jogador.cs` e `InterfaceDeUsuario.cs`. PlayerPrefs persiste três opções. Menu e loja desabilitam controles sem parar a simulação. Morte usa escala de tempo zero. O índice padrão de qualidade no código é 3, enquanto há três níveis configurados, de índices 0 a 2. O efeito em primeira execução precisa de teste. |
| Créditos e identidade | Implementado | `MenuPrincipal.unity` contém painel, foco e eventos de retorno a Configurações. A versão visual 9.4.7 diverge do `bundleVersion` 1.0.0 de `ProjectSettings.asset`. O GUID do ícone padrão resolve para [Icone_Zombie_Chaos.png](../Assets/Artes/Icone_Zombie_Chaos.png). |
| Áudio ambiente e pontual | Implementado | `FundoMusical` e `FundoMusical2` nas duas cenas referenciam `Assets/Horror Elements/Ambient/Amb_Burn.wav` e `Assets/Audios/MX/Ambience/CoFLoop1.wav`. `Game.unity` referencia `Assets/Audios/Headshot.wav` e `Assets/Audios/Menu/Menu_Buttons_8.wav`. Scripts e prefabs ligam fontes aos eventos listados no GDD. |
| História, fases lineares e desfecho de vitória | Não confirmado | A lista de build, os eventos de menu e o ciclo de `GeradorDeMonstros.cs` sustentam uma arena de sobrevivência. Cenas de exemplo e nomes de arquivos não confirmam fases extras, história, chefe ou final. |
| Progressão persistente e online | Não confirmado | `PlayerPrefs` é usado para opções. Estado de rodada, saldo e abates residem em memória. Multiplayer Center está declarado no manifesto e não estabelece uma integração de rede no loop. |
| Port móvel | Não confirmado como produto ou plano aprovado | Possibilidade discutida informalmente. Não há evidência de build, branch ou cronograma móvel nas fontes inspecionadas. O projeto usa HDRP com controles de PC. |

## 3. Divergências do documento histórico

| Tema | Documento antigo | Base atual |
|---|---|---|
| Engine e arquitetura | Mistura Unity/C# com Godot/GDScript e cenas 2D | Unity 6000.0.35f1, C#, HDRP e composição de componentes em cena |
| Modos e conteúdo | Apresenta Modo Fase, Arcade Arena e capítulos com Floresta Azul, Vila das Algas e Cidade Industrial | Menu e arena temporizada no build. A presença de exemplos de mapas não ativa modos adicionais |
| Gatilho da onda | Avanço ao eliminar o último zumbi | Corrotina temporal, independente de sobreviventes |
| Progressão de atributos | Multiplicadores de atributos por onda | Atributos fixos por prefab. A fórmula altera elegibilidade, duração e composição |
| Narrativa e mecânicas externas | Lost Souls & Guidelights, Limbo, Guidelight, Grimório, palavras-runa e ensino de inglês | Esses trechos pertencem a outro projeto e foram excluídos do GDD. No Zombie Chaos há premissa de sobrevivência e narrativa explícita sem evidência |
| Salvamento e conteúdo pedagógico | Propõe inventário, diálogo e salvamento de progresso | Persistência de sensibilidade, áudio e qualidade. Conteúdos e progresso entre partidas sem confirmação |
| Desempenho | Cita 60 FPS, 4 GB de RAM e Windows 10/11 | Sem ensaios ou base de homologação para endossar os números ou versões de sistema |
| Datas e atribuições | Cronograma e tarefas incluem conteúdo externo | Plano por etapas sem datas inventadas. Funções conferidas nos créditos atuais |

## 4. Decisões pendentes e recomendações de revisão

- Confirmar público-alvo, classificação indicativa e versão pública. Se a equipe optar por narrativa explícita, registrar sua autoria, escopo e materiais de apresentação em revisão futura.
- Gerar um executável Windows identificado pelo commit e arquivar o resultado de CT01 a CT15, distinguindo logs, observações e defeitos reproduzidos.
- Medir a inicialização e registrar a máquina de apresentação. Anotar se a latência ocorre na primeira abertura, no menu ou na transição para a arena.
- Verificar primeiro a recarga parcial, o HUD na troca, os ataques de cada variante e o comportamento de spawns e bolas ácidas durante uma sessão longa. A equipe deve decidir se ajustes são necessários para a entrega.
- Confirmar agenda acadêmica, distribuição das tarefas de fechamento, procedência e condições de redistribuição de recursos antes de publicação. Não foi feita auditoria de licenças.
- Decidir se a suspensão dos controles com o relógio ativo é a regra desejada para loja e menu de pausa. O texto atual descreve a execução prevista pelo código.

## 5. Cobertura da entrega

A edição principal percorre as 15 seções do modelo IFAM com subitens numerados. Itens condicionais, como narrativa explícita, vitória, salvamento de progresso, banco de dados e segurança online, trazem a justificativa de aplicabilidade. O GDD detalha regras e critérios de aceitação, enquanto esta auditoria identifica evidências, lacunas e divergências. As figuras de UI são esquemas conceituais. O ícone é um recurso real identificado em Player Settings.
