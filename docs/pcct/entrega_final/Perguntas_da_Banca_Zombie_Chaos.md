# Perguntas da banca — Zombie Chaos

Respostas de apoio para a etapa de perguntas, após os 15 minutos. Os casos em execução seguem identificados como verificação proposta.

### 1. Por que usar Unity e C#?
A Unity reúne cenas, componentes, física, animação, navegação e UI. C# conecta as regras de combate, movimento, economia e partida aos componentes.

### 2. Como a arquitetura está organizada?
Cenas organizam o fluxo, prefabs representam objetos reutilizáveis e scripts guardam comportamento. Referências serializadas, chamadas diretas e eventos ligam os sistemas.

### 3. Onde fica o estado da partida?
`Jogador` guarda vida, pontos e abates. `GeradorDeMonstros` administra o relógio. Armas, loja e UI têm estados próprios. PlayerPrefs guarda apenas preferências.

### 4. Como vocês detectam um disparo?
O gerenciador verifica cadência e munição, depois lança um raycast a partir da câmera. Ele usa uma máscara de camadas e ignora triggers.

### 5. Qual é a diferença entre região de dano e hitbox ofensiva?
A região receptora associa um collider a `ParteDoCorpo`. A hitbox ofensiva registra a presença do jogador e é consultada no evento do golpe. São objetos e caminhos diferentes.

### 6. O que muda entre os cinco inimigos?
Zombie, Mutante e Lobisomem têm regiões segmentadas. A Aranha recebe dano médio em um BoxCollider. Migo recebe dano médio numa cápsula e usa uma bola ácida para atacar.

### 7. Por que o dano alto gera headshot?
O gerenciador classifica como headshot o abate cujo último disparo atingiu um receptor de nível alto. Isso dobra a recompensa. Cada arma define separadamente os valores de dano.

### 8. Como a bola ácida se move?
O lançamento orienta o ponto para o jogador. O prefab usa ConstantForce local de 8 no eixo Z e Rigidbody sem gravidade. O trigger aplica dano ao tocar Player.

### 9. Vocês usam uma máquina de estados para IA?
A lógica C# decide por distância e intervalo. O Animator possui os estados de animação. O cálculo de caminhos usa NavMeshAgent e duas superfícies na arena.

### 10. A onda espera todos os inimigos morrerem?
A onda avança pelo tempo. Seu início restaura a vida e a variedade de prefabs cresce por faixas. Inimigos restantes podem continuar no mapa.

### 11. Como a equipe utilizou Scrum?
A equipe relata Scrum adaptado ao longo de sete meses. Agrupamos o processo em incrementos de integração. A linha do tempo é uma reconstrução por frentes, com atividades sobrepostas.

### 12. Qual foi a função do Trello?
A equipe o usou para organizar atividades. O diagrama ilustra como uma tarefa vai da priorização à verificação e pode voltar para ajustes, sem representar uma captura do quadro histórico.

### 13. Quais requisitos foram validados?
A inspeção confirma a integração estática dos fluxos centrais. Há relato de abertura de uma build Windows. Os testes de aceitação em execução de uma build identificada seguem pendentes.

### 14. Como vocês avaliam desempenho?
Medimos, no plano de validação, abertura, tempo de quadro, memória e agentes ativos, com hardware e perfil HDRP registrados. Nenhuma taxa de quadros foi aferida nesta auditoria.

### 15. Qual melhoria faria mais sentido agora?
Validar uma sessão até Game Over e reproduzir recarga parcial, HUD na troca e eventos de ataque por variante. Depois, priorizar ajustes a partir do impacto observado.

## Perguntas sobre a HDRP

### 16. O que significa HDRP?
High Definition Render Pipeline. É uma implementação da infraestrutura de renderização configurável da Unity, voltada à alta fidelidade em plataformas compatíveis.

### 17. O que é uma render pipeline?
É a organização das etapas que produzem o quadro, desde a seleção de objetos e da câmera até o trabalho de shaders, luzes, composição e efeitos.

### 18. Qual é a diferença entre HDRP e URP?
A URP prioriza escalabilidade em mais tipos de dispositivo. A HDRP prioriza ferramentas para alta fidelidade em hardware compatível. Cada uma tem shaders, recursos e perfis próprios. A comparação é documental.

### 19. Por que a HDRP foi escolhida para o Zombie Chaos?
Para controlar a luz industrial, a resposta das superfícies e a atmosfera de uma arena escura para PC, integrando a apresentação visual ao combate e à navegação.

### 20. Como foi configurada?
O projeto usa Unity 6000.0.35f1 e HDRP 17.0.3. GraphicsSettings define o asset padrão e os Global Settings. QualitySettings liga Baixo, Médio e Alto a Performant, Balanced e High Fidelity.

### 21. Qual é a relação com PBR?
A HDRP implementa iluminação e materiais fisicamente fundamentados. O material HDRP/Lit do Zombie usa cor base, normal, máscara e emissão para calcular a resposta da superfície. A máscara agrega metallic, oclusão, detalhe e smoothness.

### 22. Como a iluminação ajuda a ambientação de terror?
A luz direcional, as fontes locais e as sombras organizam áreas de luz e contraste. A neblina ajuda a separar planos onde o perfil permite. A legibilidade de inimigos e rotas deve ser observada em gameplay.

### 23. O que são Volumes?
Conjuntos de parâmetros de renderização usados pela câmera. O ambiente tem Volumes globais com peso 1. Um Volume de dano em Game começa em 0 e o script altera seu peso durante o feedback.

### 24. Quais efeitos foram utilizados?
Os perfis de ambiente registram exposição automática, bloom, vinheta e SSAO, entre outros ajustes. O perfil padrão seleciona ACES. O Volume de dano tem ajustes de cor, aberração cromática e motion blur. A auditoria verificou ligações e configurações, e os efeitos em runtime ainda precisam de captura.

### 25. A HDRP melhora automaticamente a qualidade?
A pipeline oferece controles. O resultado depende de iluminação, arte, materiais, câmera, composição e recursos disponíveis no perfil. É preciso observar se as decisões melhoram a leitura da cena.

### 26. Qual é o impacto da HDRP no desempenho?
Sombras, volumetria e pós-processamento podem aumentar trabalho de GPU e uso de memória. O efeito no jogo depende de hardware, resolução e configuração. Falta medir em condições controladas.

### 27. O projeto poderia usar URP?
Seria tecnicamente possível realizar uma conversão, com revisão de shaders, materiais, Volumes, iluminação e compatibilidade. O jogo atual é HDRP, e a auditoria não identificou teste ou migração histórica comprovada.

### 28. Quais são as limitações mais relevantes?
Requisitos de hardware e API, custo gráfico e recursos que variam conforme o perfil. No projeto, Baixo desabilita suporte volumétrico, SSR e ray tracing estão desabilitados nos três níveis e SSGI é permitido só em Alto, com uso em cena ainda não confirmado.

### 29. Como os resultados visuais foram verificados?
Foram cruzados arquivos de Graphics, Quality, câmeras, luzes, perfis e referências de materiais. Os mapas originais foram reunidos como evidência dos assets. A captura de execução e a comparação controlada dos níveis continuam no plano de evidências.

### 30. Qual é a contribuição da HDRP para o PCCT?
Ela tornou explícitas as decisões de renderização da arena e permitiu ligar ciência da computação gráfica, integração de assets e feedback visual ao desenvolvimento do jogo.

### 31. A HDRP influencia o sistema de colliders e áreas de dano?
A HDRP processa a imagem. A física e os scripts de gameplay consultam colliders e calculam dano. O Volume de dano altera a imagem depois que a lógica do jogo registrou o evento.
