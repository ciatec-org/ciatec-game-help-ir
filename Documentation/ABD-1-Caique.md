---
faixa: CIATec
doc: Plano de trabalho
doc_extenso: Agile Backlog Document
titulo: Help-IR
subtitulo: Plano de trabalho do jogo de iniciação científica do Caique
versao: v1.1
mudanca: o gerador de fases por arquivo de texto no Core e o visual da caixa no HUD, ideias do Caique (26/11/2026); v1.0 reescrito no molde do Caça às Cores
data: 26/11/2026
projeto_vinculado: Help-IR
organizacao: CIATec
triple_diamond:
ppi:
pesquisador: Carlos Monteiro
tipo: backlog
status: rascunho
data_criacao: 25/11/2026
data_atualizacao: 26/11/2026
---

# 1 COMO USAR ESTE PLANO

## 1.1 Para quem é

**Este plano é para o Caique, que faz o Help-IR na iniciação científica.** Ele diz o que construir, em que ordem, e em pedaços pequenos o bastante para caber numa sessão de trabalho. O que o jogo é, e por quê, está no SGDD (`SGDD-1-Caique.md`, ao lado): este plano não decide nada sobre o jogo, só organiza o trabalho de construí-lo. **Toda dúvida sobre como algo deve acontecer se responde no SGDD**; se ele não responde, a dúvida vai ao orientador, e a resposta volta ao SGDD.

**A tecnologia é Unity 3D, para o PC** (Windows, mouse e teclado; decisão do orientador de 26/11/2026, "pra simplificar"): Unity 6000.5.7f1, URP 17.5.0, Input System 1.20.0 e Test Framework 1.7.0. Não há build móvel nem vibração; os botões de toque que o código do Caique já tem ficam. O código fica em `Assets/Game/`; a primeira task (T-01.1.1) cria o asmdef do jogo, `HelpIR`, e os de teste, `HelpIR.Tests.EditMode` e `HelpIR.Tests.PlayMode`. Os testes simulam o teclado com o `InputTestFixture` do Input System, e o tempo (cronômetros, tetos, animações com duração) passa pelo `Agentes.Relogio`, para o teste poder avançá-lo. O repositório usa campos `public` e singletons (`GameManager`, `SettingsManager`): vale o padrão dele.

## 1.2 Os dois milestones

**O backlog cobre o SGDD inteiro, em dois milestones sem data** (decisão do orientador, 26/11/2026).

- **Core** é o jogo direto, sem tutorial, com a mecânica inteira: o menu com o seletor de fases e o código do participante, o robô e os controles, o ciclo da entrega com as placas e a seta-guia, as Fases 1 a 5 com todas as perturbações (fumaça, placas escondidas e bloqueios) e a entrada delas depois do começo limpo, os limites de tempo fixos do Suporte 1, o fim de fase e a conclusão que avança para a fase seguinte, a pausa e o volume, a telemetria gravada em arquivo local e o documento do formato dela, e a build de PC. O botão [Tutorial] do menu e o card "(Treino)" do carrossel ficam como o Caique os fez.
- **Expansão** tem todo o resto, sem corte: o tutorial (a Fase 0 inteira), o painel do mediador, os presets por perfil, a interface que recebe os parâmetros da partida, a paleta restrita e o brilho, a arte e o áudio finais, a abertura, Libras e as métricas derivadas do arquivo da sessão.

**Cada épico pertence a um milestone só** (orientador, 26/11/2026): os EP-01 a EP-04 são do Core, e os EP-05 a EP-07, da Expansão. Nenhuma história do Core depende de uma da Expansão.

**A conexão com a API não está neste backlog:** é de outro momento ("os três projetos precisam criar um arquivo local, conexão com API vem num outro momento", orientador, 25/11/2026), e as histórias dela estão em `ABD-1-Caique-api.md`, ao lado. **A adaptação de dificuldade é do backend** (padrão CIATEC): o jogo recebe os parâmetros da partida por uma interface, aplica-os e grava o que recebeu (US-06.3); sem rede, um provedor local devolve os do preset da fase, sem regra.

## 1.3 O que já existe

**O que o Caique já implementou na branch `fase0` é decisão dele e vale** (regra do orientador, 26/11/2026). Onde o código já decide uma regra, o SGDD e este plano seguem o código, com a marca "conforme a implementação do aluno", e nada se refatora para a regra antiga. Cada coisa que o código já faz é uma **task fechada** dentro da história nova, com o `arquivo:linha` e "já existe" na coluna de horas: ela não conta nas horas, e no CSV leva o label `ja-existe`. As tasks a fazer dizem só o que falta.

## 1.4 Pronta para começar, e pronta de verdade

**Uma história está pronta para começar** quando o Caique leu as seções do SGDD que ela cita, as dependências dela estão feitas, e não há dúvida aberta sobre o que ela pede. As decisões provisórias que ela usa (seção 7.3) começam valendo.

**Uma história está feita** quando:

- cada requisito da lista dela foi visto acontecer, jogando no Play do Editor;
- os testes das tasks que escrevem regra passam no Test Runner do Editor;
- o Console não mostra nenhuma exceção durante uma fase jogada.

**Teste só onde há regra:** a task que escreve uma regra em C# puro traz o teste EditMode ou PlayMode dela; não há task só de teste.

## 1.5 Como ler uma história

Cada história traz o perfil, as horas, a prioridade, o milestone e de que histórias depende; a história no formato *Como… quero… para que…*; **a lista dos requisitos do SGDD que ela realiza, um por linha** — os `RT-xx` são as linhas da §12 do SGDD, com o texto dela, e as outras citam a seção e a decisão (LG-Cai, LAC, LA) de onde vêm; os cenários de aceite; e as tasks, de 1 ou 2 h cada, com a camada (gameplay, presentation, dados, conteúdo, arte, telemetria, build). Montar na cena entra na mesma task do código.

> **As histórias de marco** (uma por milestone: US-04.5 e US-07.5) só fecham com a build de PC jogada do menu ao fim e o arquivo de telemetria conferido contra o que foi jogado. São a única prova de que as peças foram juntadas.

## 1.6 O que ficou fora

Ficam fora do backlog, por decisão do orientador (26/11/2026): a burocracia (conferir e anotar na issue, medições, validação com o documento na mão, capturas), o teste-robô, os validadores do mapa, o JSON Schema, o tutorial no Core, a build móvel e a vibração, a adaptação de dificuldade (é do backend), ética, consentimento e dados (CEP e backend), estudos, pilotos, relatório e propostas ao pesquisador. O que saiu em cada versão, com o motivo, está no ABD v0.11 (`I:\Ciatec\tmp-claude\abd-final\Caique\antes-molde-caca\ABD-1-Caique.md`); o que cada história e task antiga virou está no mapa (`I:\Ciatec\tmp-claude\abd-final\Caique\mapa-molde-caca.md`). **Ficam como evento externo**, fora do backlog e escritos na história a que servem: a gravação dos vídeos em Libras por um intérprete (US-05.2) e a mediação física e a demonstração guiada dos Suportes 2 e 3 (US-06.2).

# 2 TAMANHO

**O plano tem 7 épicos, 25 histórias e 72 tasks a fazer, somando 140 horas**, mais 19 tasks já feitas pelo código da `fase0`. **O plano conta em horas, e não em pontos**, e as horas são previsão (LA-08): o Caique as corrige ao puxar cada task. Os milestones não têm data.

| Épico | Milestone | Histórias | Tasks a fazer | Já existem | Horas |
| --- | --- | --- | --- | --- | --- |
| EP-01 · O projeto e o menu | Core | 2 | 3 | 3 | 6 h |
| EP-02 · O robô, as placas e a entrega | Core | 4 | 10 | 9 | 19 h |
| EP-03 · As fases e as perturbações | Core | 3 | 12 | 2 | 24 h |
| EP-04 · Fim, pausa e registro da sessão | Core | 5 | 13 | 3 | 26 h |
| EP-05 · O tutorial da Fase 0 | Expansão | 2 | 7 | 1 | 14 h |
| EP-06 · O mediador, os perfis e os ajustes sensoriais | Expansão | 4 | 11 | 1 | 21 h |
| EP-07 · Arte, som e métricas finais | Expansão | 5 | 16 | 0 | 30 h |

| Milestone | Histórias | Tasks a fazer | Já existem | Horas | O que se vê |
| --- | --- | --- | --- | --- | --- |
| Core | 14 | 38 | 17 | 75 h | A build de PC, do menu ao fim das Fases 1 a 5, com a seta-guia, as perturbações e o arquivo de cada sessão (US-04.5) |
| Expansão | 11 | 34 | 2 | 65 h | A sessão conduzida pelo mediador, com a Fase 0, os perfis, a arte e o áudio finais e as métricas (US-07.5) |

# 3 ÉPICOS

Cada épico está inteiro na seção 4: a descrição, por que importa, quando está pronto, e as histórias e tasks dele.

| Épico | Domínio e milestone | Depende de |
| --- | --- | --- |
| EP-01 · O projeto e o menu | Infra · Core | — |
| EP-02 · O robô, as placas e a entrega | Gameplay · Core | EP-01, EP-04 |
| EP-03 · As fases e as perturbações | Gameplay · Core | EP-02 |
| EP-04 · Fim, pausa e registro da sessão | Telemetria · Core | EP-01, EP-02, EP-03 |
| EP-05 · O tutorial da Fase 0 | Interface · Expansão | EP-02, EP-03 |
| EP-06 · O mediador, os perfis e os ajustes sensoriais | Mediador · Expansão | EP-01, EP-02, EP-03, EP-04, EP-05 |
| EP-07 · Arte, som e métricas finais | Interface · Expansão | EP-01, EP-02, EP-04, EP-05, EP-06 |

# 4 ÉPICOS, HISTÓRIAS E TASKS

As histórias estão na ordem em que se fazem dentro de cada épico, e as tasks de cada uma também: as de cima vêm primeiro. A ordem entre épicos está na seção 5.

## 4.1 EP-01 — O projeto e o menu

**Milestone:** Core

O que o Caique já fez na branch `fase0` vai para a `develop`, com a estrutura que os testes pedem, vira uma build de Windows, e o menu leva à fase escolhida.

**Por que importa:** Todo o resto parte de um projeto que abre, roda e se joga fora do Unity.

**Pronto quando:**

- A `develop` abre sem erro, com o asmdef do jogo e os de teste;
- A build de Windows abre num PC sem Unity;
- O menu leva à fase escolhida no carrossel.

## 4.1.1 US-01.1 — O projeto da `fase0` abre na `develop` e vira um jogo de PC

**Perfil:** IC · **Horas:** 4 · **Prioridade:** P1 · **Milestone:** Core

**Depende de:** —

*Como IC, quero levar o que já fiz na branch `fase0` para a `develop`, com a estrutura que os testes pedem, e gerar a build de Windows, para que todo o resto parta de um projeto único que abre, roda e se joga fora do Unity.*

**Requisitos do SGDD que ela realiza:**

- §7.4 — a build de Windows abre e chega do menu ao fim de uma fase
- §10.3-2 — a interface cabe na tela do PC (1920×1080, 16:9) sem cortar HUD nem botões

**Cenários de aceite:**

- Dado a `fase0` integrada à `develop`, quando o projeto é aberto e se dá Play no Menu, então o Menu aparece, [Jogar] leva ao Gameplay sem exception, e o Test Runner mostra os asmdefs `HelpIR.Tests.EditMode` e `HelpIR.Tests.PlayMode`.
- Dado um arquivo da `fase0` que conflita com a `develop`, quando o PR é aberto, então o conflito se resolve antes do merge, e nenhum arquivo da `fase0` some.
- Dado a build gerada, quando ela é aberta num PC sem Unity, então o menu aparece, a Fase 1 joga, e o `Player.log` não tem exception.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-01.1.1 | Criar o asmdef do jogo `HelpIR` (Input System, TextMeshPro, UI e o `Agentes.Runtime`) e os de teste `HelpIR.Tests.EditMode` e `HelpIR.Tests.PlayMode` (com `Unity.InputSystem.TestFramework`), a linha `"testables": ["com.unity.inputsystem"]` no `Packages/manifest.json` e um teste EditMode mínimo; pôr as classes de `Assets/Game/` no namespace `HelpIR`, sem mudar nome de classe nem de campo; e renomear no Editor `MainMenuController.cs` para `MenuPrincipalController.cs` e `FaseDataS0.cs` para `FaseDataSO.cs`, conferindo que a cena Menu e os três `Fase_*.asset` continuam com o script | 2 h · build |
| T-01.1.2 | Abrir o PR `fase0` → `develop` e resolver os conflitos; ajustar o Canvas Scaler de cada Canvas para a tela do PC (referência 1920×1080) e gerar a build de Windows fora do repositório | 2 h · build |
| T-01.1.3 | As cenas Menu, Gameplay e Results no Build Settings, com o Menu primeiro (`ProjectSettings/EditorBuildSettings.asset`) | já existe · build |

## 4.1.2 US-01.2 — Escolher a fase no menu e começar

**Perfil:** Criança · **Horas:** 2 · **Prioridade:** P1 · **Milestone:** Core · **Issue:** #2

**Depende de:** US-01.1

*Como criança, quero ver poucos botões grandes, com ícones, e escolher a fase no carrossel, para que eu comece a jogar sem precisar ler.*

**Requisitos do SGDD que ela realiza:**

- §10.3-1, LA-09 — o menu mostra [Jogar], [Tutorial] e [Configurações], com ícones grandes, e [Sair], que fecha o jogo (conforme a implementação do aluno)
- §10.2 Linguístico — nenhum botão depende de texto para ser entendido
- §10.3-1 — cada botão leva à tela certa
- §2.2, §7.4 — os botões respondem ao clique do mouse e ao teclado
- §10.3-1, LA-13 — [Jogar] abre o seletor de fases, e tocar o card central abre a fase (conforme a implementação do aluno)

**Cenários de aceite:**

- Dado o menu aberto, quando a criança toca em [Jogar], então o seletor de fases abre, e tocar o card central abre a fase.
- Dado o menu aberto, quando ela toca em [Configurações], então o painel abre por cima do menu, e fechar volta ao menu.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-01.2.1 | Ligar no `Awake` do `MenuPrincipalController` os botões dos campos `botaoJogar`, `botaoTutorial`, `botaoConfiguracoes` e `botaoSair` aos métodos que já existem (`ClicarStart`, `ClicarTutorial`, `ClicarOptions` e `ClicarExit`); na cena Menu, deixar os quatro botões com ícones grandes e sem texto, ligá-los aos campos e apagar o OnClick antigo de cada um, para cada clique chamar o método uma vez só | 2 h · presentation |
| T-01.2.2 | O `MenuPrincipalController` (em `MainMenuController.cs`): [Start] abre o seletor de fases (`ClicarStart` e `FecharSelecaoFases`, :10-20); [Tutorial] carrega a Gameplay com a Fase 0 (`ClicarTutorial`, :22-28; `GameManager.SelecionarTutorial` e `faseTutorialPadrao`, GameManager.cs:8, :30-33); o painel de opções abre e fecha (`ClicarOptions` e `FecharOptions`, :30-40); [Sair] fecha o jogo (`ClicarExit`, :42-48) | já existe · presentation |
| T-01.2.3 | O carrossel de fases (`LevelSliderController.cs` e `Image_CardFase.prefab`): cor de destaque e número no card (:35-76), os cards "Fumaça", "Bloqueio" e "(Treino)" (:56, :64-65), e tocar o card central carrega a cena da fase (:163-197), com a fase escolhida no `GameManager` | já existe · presentation |

## 4.2 EP-02 — O robô, as placas e a entrega

**Milestone:** Core

O coração do jogo: o robô anda e gira vendo à frente, segue as placas da cor, pega a caixa na doca e a entrega no setor certo, com o retorno suave do acerto e o do erro, o HUD e a seta-guia na 1ª entrega.

**Por que importa:** É a tarefa que o estudo observa: a navegação pelas placas e a entrega pela cor.

**Pronto quando:**

- Seguir as setas de uma cor leva ao setor dela, e as da doca, à doca;
- Uma entrega joga inteira, com o retorno de acerto, o do erro e o HUD.

## 4.2.1 US-02.1 — Andar e girar o robô, vendo o que está à frente

**Perfil:** Criança · **Horas:** 2 · **Prioridade:** P1 · **Milestone:** Core

**Depende de:** US-01.1

*Como criança, quero andar e girar o robô com as setas, com W, A, S e D ou com os botões da tela, e ver o que está à frente dele, para que eu explore a fábrica e precise girar para descobrir os caminhos.*

**Requisitos do SGDD que ela realiza:**

- `RT-01` — Navegação 3D egocêntrica com orientação por placas de cores em intersecções
- `RT-12` — Suporte duplo a controles: Teclado (PC) e botões virtuais touchscreen amplos (Tablets) *(v1.3, 26/11/2026: o dispositivo-alvo é o PC; ver §2.2.)*
- §4.1 — W/↑ avança e S/↓ recua o robô; segurar A/← ou D/→ gira o robô de forma contínua, a 110°/s vezes a sensibilidade do esquema ativo, e a câmera gira junto (conforme a implementação do aluno; LG-Cai-04)
- §4.1, REQ-P3-02, LG-Cai-03 — o robô anda na velocidade do dado da fase, em m/s (conforme a implementação do aluno)
- §10.2 Motor — nenhuma ação exige duas teclas ao mesmo tempo
- LAC-09 — o mouse não move o robô, e a sensibilidade do painel de opções, de 0,2× a 3×, multiplica o giro (conforme a implementação do aluno)
- §4.1, §10.3-2, LAC-10 — a câmera acompanha o robô, alinhada à frente dele, com o robô visível e 60° de campo de visão na vertical; o que está atrás e dos lados não aparece sem girar
- §4.1, REQ-P1-04 — quatro botões na tela replicam avançar, recuar, girar à esquerda e girar à direita enquanto seguros, fixos nas extremidades inferiores (conforme a implementação do aluno)

**Cenários de aceite:**

- Dado o robô parado num corredor, quando a criança segura W, então ele anda para a frente; e, de frente para uma parede, para nela sem atravessá-la.
- Dado o robô parado numa intersecção, quando a criança segura D e solta, então ele gira para a direita enquanto D está apertado, para ao soltar, e o corredor lateral aparece na tela.
- Dado o jogo aberto, quando a criança segura a seta de cima da tela, então o robô avança.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-02.1.1 | Passar a leitura do `RoboController` do `Input` legado (`Input.GetKey`, :46-49) ao Input System, com os campos `acaoAvancar`, `acaoRecuar`, `acaoGirarEsquerda` e `acaoGirarDireita`, sem mudar o movimento, o giro, a sensibilidade nem a soma com os botões (:52-55); criar o mapa Robo no `InputSystem_Actions.inputactions` (W/↑, S/↓, A/←, D/→) e ligá-lo no `Robo` da cena Gameplay; teste PlayMode do gesto, com o teclado do `InputTestFixture` e o `Agentes.Relogio`: segurar W anda na velocidade do dado e soltar para; segurar A ou D gira a 110°/s vezes a sensibilidade | 2 h · gameplay |
| T-02.1.2 | Movimento e giro contínuos: W/↑ e S/↓ andam, A/← e D/→ giram (RoboController.cs:46-49), na velocidade do dado da fase (:28-31) e a 110°/s (:8, :58-62), pelo `Rigidbody`; a sensibilidade de 0,2× a 3× por esquema de controle multiplica o giro (SettingsManager.cs:5-10, :20-24, :68-74; PainelOptionsUI.cs:15-17, :60-82; RoboController.cs:17, :34-37, :60) | já existe · gameplay |
| T-02.1.3 | A câmera presa ao robô: a Main Camera é filha do `Robo` na cena Gameplay, em (0; 1; −0,5), gira com ele e tem 60° de campo de visão na vertical (`m_FOVAxisMode: 0`; `Gameplay.unity`) | já existe · presentation |
| T-02.1.4 | O `BotaoTouchDirecional` move e gira o robô enquanto seguro, somado ao teclado (BotaoTouchDirecional.cs; RoboController.cs:52-55) | já existe · gameplay |
| T-02.1.5 | Os botões `Btn_Foward`, `Btn_Backward`, `Btn_Left` e `Btn_Right` da cena Gameplay, com o `BotaoTouchDirecional`, ligados a `btnFrente`, `btnTras`, `btnEsquerda` e `btnDireita` do `RoboController` (`Gameplay.unity`) | já existe · presentation |

## 4.2.2 US-02.2 — Reconhecer os setores e seguir as placas da cor

**Perfil:** Criança · **Horas:** 6 · **Prioridade:** P1 · **Milestone:** Core · **Issue:** #4

**Depende de:** US-01.1

*Como criança, quero reconhecer cada setor pela cor e por um símbolo e ver, em cada cruzamento, setas da cor de cada setor apontando o caminho, para que eu siga a cor da minha caixa até o setor.*

**Requisitos do SGDD que ela realiza:**

- `RT-01` — Navegação 3D egocêntrica com orientação por placas de cores em intersecções
- §4.1 — intersecções, placas, setores, doca, pacote e ponto de início estão na cena como marcadores, e o grafo do mapa sai deles
- §11.1, §11.3 — a fase tem de 3 a 6 setores, conforme a cena dela (a Fase 0, de treino, tem 2, conforme a implementação do aluno)
- §10.3-2, §10.2 Linguístico, LAC-17 — cada setor tem uma cor e um símbolo, sem rótulo de texto
- LG-Cai-02 — a entrada de cada setor mostra a cor e o símbolo grandes, visíveis do corredor
- §4.1, LG-Cai-01 — a placa de cada direção é uma seta grande que aponta o corredor, com a cor e o símbolo do setor a que ele leva, e há setas também para a doca
- §11.1, §5.3, LA-02 — cada poste tem de 1 a 4 placas, uma por direção de chegada; cada placa leva uma seta por destino (setores ativos e doca), em até duas fileiras, e só a voltada para o robô aparece para ele
- RT-01, LG-Cai-01 — seguir sempre as setas da cor X leva ao setor X, e seguir as da doca leva à doca

**Cenários de aceite:**

- Dado um pacote azul, quando a criança segue as placas azuis, então chega ao setor azul.
- Dado uma intersecção que não leva ao setor verde, quando a criança chega a ela, então não há seta verde nela.
- Dado o robô vazio depois de uma entrega, quando a criança segue as setas da doca, então chega à doca.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-02.2.1 | `GrafoDoMapa`: lê os marcadores da cena (`Marker_Interesecao`, `Marker_SetorEntrega`, `Marker_Pacote`, `Marker_StartPoint` e `Marker_Placa`) e os tiles de piso entre eles e monta o grafo das intersecções, com os setores (a cor lida do `corDesteSetor`), a doca e o início; pô-lo no `Mapa_Fabrica` da Gameplay e completar os marcadores que faltarem | 2 h · dados |
| T-02.2.2 | Estender o `CorSetor` (hoje azul, verde e amarelo) aos 6 setores da LAC-17, com cor e símbolo; o `SetorEntrega` aplica os dois pelos campos `rendererDoPiso` e `placaDeEntrada`, e o `CicloEntregaManager` deixa os três materiais fixos (:8-10, :82-87) e pega a cor do mesmo lugar; criar os materiais que faltam (laranja, roxo e rosa), os 6 símbolos provisórios, a placa grande na entrada do setor e o prefab da placa como seta grande no poste (seta, fundo e símbolo), com o ícone provisório da doca | 2 h · conteúdo |
| T-02.2.3 | Estender o `ControladorPlacas`, que já tem as quatro placas: pelo grafo do mapa, cada placa é uma seta por destino (setores ativos e doca), com a cor e o símbolo, em até duas fileiras, apontando o corredor da rota mais curta (campos `seta`, `fundo` e `simbolo`); teste EditMode: para cada setor, o caminho pelas setas da cor chega a ele, e o das setas da doca chega à doca | 2 h · gameplay |
| T-02.2.4 | Três cores de setor e o setor com a cor dele: o `CorSetor` (azul, verde e amarelo; CorSetor.cs), o `corDesteSetor` (SetorEntrega.cs:5), os `Mat_Setor_Amarelo`, `Mat_Setor_Azul` e `Mat_Setor_Verde`, e dois setores na cena (azul e verde) | já existe · conteúdo |
| T-02.2.5 | Uma placa por direção no poste (norte, sul, leste e oeste), ligada ou desligada (ControladorPlacas.cs:13-78, no prefab `Poste`) | já existe · gameplay |

## 4.2.3 US-02.3 — Levar a caixa ao setor da mesma cor

**Perfil:** Criança · **Horas:** 9 · **Prioridade:** P1 · **Milestone:** Core

**Depende de:** US-02.2

*Como criança, quero pegar a caixa na doca, levá-la ao setor da mesma cor e ver, com suavidade, que acertei — ou perceber, sem castigo, que o setor não era o certo —, para que eu saiba o que fazer e siga sem me frustrar.*

**Requisitos do SGDD que ela realiza:**

- `RT-02` — Mecânica de entrega de pacotes nos setores fabris correspondentes à cor
- `RT-06` — Feedback de acerto suave e focado (brilho direcionado no setor sem flashes piscantes)
- `RT-09` — Eliminação total de alarmes de erro, buzinas e timbres estridentes em falhas
- `RT-11` — Interface minimalista (HUD) com enquadramento exclusivamente positivo de pontos acumulados
- §5.1, LG-Cai-11 — encostar no pacote dá ao robô vazio uma caixa, que aparece no encaixe dele; depois da entrega, o pacote reaparece na cor seguinte da alternância azul/verde (conforme a implementação do aluno)
- §4.2 A — entrar no setor da cor da caixa da vez conclui a entrega: o brilho acende e apaga na cor do setor numa curva suave, sem piscar; a caixa vai ao depósito do setor; toca o SFX de acerto, curto e ascendente, e o robô faz a animação curta de confirmação
- §4.2 C — o contador de entregas sobe um
- §4.2 B, LG-Cai-13 — no setor errado, o robô entra sem barreira, a caixa fica com ele — a retenção é o indicador neutro do impedimento — e toca o baque grave e curto (110 Hz); nunca alarme
- §4.2 B, LG-Cai-13 — no setor errado, o ícone da caixa no HUD pulsa na cor dela, uma vez por tentativa, sem piscar nem mudar de cor
- §10.3-2, LG-Cai-23 — um canto do HUD mostra a cor e o símbolo da caixa que o robô leva; o canto oposto, o contador de entregas, uma caixinha por entrega, em fileiras de 10, sem número, que só sobe; o botão de pausa fica discreto, no alto
- §4.2 C, §10.1 — não há vidas, cronômetro, texto, tela de erro nem perda de ponto

**Cenários de aceite:**

- Dado o robô com a caixa azul da vez, quando entra no setor azul, então a caixa vai ao depósito, o brilho azul e o som aparecem, e o contador ganha uma caixinha.
- Dado o robô com a caixa azul da vez, quando entra no setor verde, então a caixa continua com ele, o ícone azul do HUD pulsa, e o contador não muda.
- Dado 10 caixinhas no contador, quando a 11ª entrega se conclui, então a caixinha nova abre a segunda fileira.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-02.3.1 | Tirar do `CicloEntregaManager` (:49-58) para uma classe em C# puro a regra da entrega que já existe (a cor da caixa da vez é a do setor; o contador sobe; o setor errado não muda nada), com teste EditMode; e o teste PlayMode do ciclo que já existe: encostar no pacote dá a caixa ao robô vazio, com caixa não dá outra, a entrega sobe o contador e o pacote reaparece na cor seguinte | 2 h · gameplay |
| T-02.3.2 | `BrilhoDeEntrega`: acende e apaga a emissão na cor do setor numa curva suave, sem piscar, nos renderers do campo `renderers`; a caixa vai ao ponto de depósito do setor (campo `deposito` do `SetorEntrega`) numa interpolação curta; pôr o brilho nos prefabs do robô e do setor e marcar o depósito no prefab do setor | 2 h · presentation |
| T-02.3.3 | Na entrega, tocar o clipe do campo `somAcerto` e disparar o gatilho Confirmar do campo `animadorDoRobo`; fazer o SFX provisório, curto e ascendente, e a animação curta de confirmação no Animator do robô, e ligá-los | 1 h · arte |
| T-02.3.4 | `HudDaFase`, empurrado pelo gerente de entregas (o HUD não lê estado), com os campos `iconeCaixa`, `areaContador`, `prefabCaixinha` e `botaoPausa`: a caixa que o robô leva no canto superior direito, como o ícone de uma caixa de entrega dentro de um quadro na cor e com o símbolo do setor dela (ideia do Caique, `Documentation/ideias-expansao.md`), e uma caixinha por entrega, em fileiras de 10, no oposto; montar o Canvas do HUD na Gameplay, com a caixinha provisória; teste PlayMode: a entrega acrescenta uma caixinha, e a 11ª abre a segunda fileira | 2 h · presentation |
| T-02.3.5 | No setor errado, onde a caixa já fica com o robô (CicloEntregaManager.cs:75-79), tocar o clipe do campo `somImpedimento` no lugar do `Debug.Log` (o baque grave provisório, 110 Hz) e avisar o `HudDaFase`, que pulsa o ícone da caixa numa escala suave, pelo `Agentes.Relogio`, sem mudar a cor; teste PlayMode: o contador não muda, e o ícone pulsa uma vez por tentativa | 2 h · presentation |
| T-02.3.6 | O robô leva uma caixa por vez: o `PacoteColetavel` só a entrega ao robô vazio (PacoteColetavel.cs:10), e ela aparece no robô (`PacoteCarregadoVisual`, campo `pacoteCarregadoVisual` do `CicloEntregaManager`, :7, :37-41); depois da entrega, o pacote reaparece alternando azul e verde (:66-73) | já existe · gameplay |
| T-02.3.7 | O `SetorEntrega` chama a entrega quando o robô entra com caixa (SetorEntrega.cs:7-13), e o `CicloEntregaManager` confere a cor e sobe o `entregasConcluidas` (:49-58) | já existe · gameplay |
| T-02.3.8 | No setor errado, a caixa fica com o robô, sem barreira nem punição (CicloEntregaManager.cs:75-79) | já existe · gameplay |

## 4.2.4 US-02.4 — Uma seta mostra aonde ir

**Perfil:** Criança · **Horas:** 2 · **Prioridade:** P1 · **Milestone:** Core

**Depende de:** US-02.3, US-04.1

*Como criança, quero que uma seta me mostre aonde ir quando eu ainda não sei, para que eu entenda que busco a caixa na doca e a levo ao setor da mesma cor.*

**Requisitos do SGDD que ela realiza:**

- LG-Cai-02 — a seta aponta a doca com o robô vazio e o setor da caixa depois da coleta, na 1ª entrega de cada fase, e só nela (a Fase 0 é da Expansão, US-05.1)
- LG-Cai-05, LA-03 — numa entrega que passa de 30 s, a seta volta a apontar o alvo da vez, até a entrega terminar
- §10.1, §10.2 Visual — a seta não pisca nem tem partícula, e não substitui as placas: só aponta o alvo

**Cenários de aceite:**

- Dado o começo da Fase 1 com o robô vazio, quando a fase começa, então a seta aponta a doca e, depois da coleta, o setor da caixa.
- Dado a 1ª entrega concluída, quando a 2ª começa, então a seta não aparece, até passar de 30 s.
- Dado a 3ª entrega passando de 30 s, quando o tempo passa, então a seta volta a apontar o setor da caixa.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-02.4.1 | `SetaGuia`, com o campo `seta`: aponta o próximo alvo (a doca com o robô vazio, o setor da caixa depois) na 1ª entrega de cada fase, e de novo quando a entrega passa de 30 s (o aviso do relógio da tentativa, T-04.1.1); teste: aponta a doca e depois o setor na 1ª entrega, some depois dela e volta aos 30 s; fazer a seta flutuante provisória, sem piscar, e ligá-la na Gameplay | 2 h · gameplay |

## 4.3 EP-03 — As fases e as perturbações

**Milestone:** Core

As Fases 1 a 5 como dados e como mapas escritos à mão em arquivos de texto, que o jogo transforma na fábrica, com as placas escondidas (fumaça, sujeira, quebrada, manutenção) e os corredores bloqueados (obra, reforma, multidão), que entram depois do começo limpo.

**Por que importa:** As perturbações são o que mede a recuperação de pista e a flexibilidade cognitiva.

**Pronto quando:**

- As cinco fases abrem com os valores do Suporte 1;
- A perturbação entra depois da 3ª entrega, aos poucos;
- Com 3 bloqueios ainda há rota até cada setor.

## 4.3.1 US-03.1 — Jogar as Fases 1 a 3, cada uma na sua fábrica

**Perfil:** Pesquisador · **Horas:** 8 · **Prioridade:** P1 · **Milestone:** Core · **Issue:** #3

**Depende de:** US-02.2, US-02.3

*Como pesquisador, quero que cada fase seja um dado com os valores do SGDD e tenha a sua fábrica fixa, escrita num arquivo de texto que o jogo transforma na fábrica, para que a dificuldade suba na ordem do protocolo e a mesma fase seja igual para todas as crianças.*

**Requisitos do SGDD que ela realiza:**

- `RT-13` — Recepção de parâmetros de fase (velocidade, fumaça, bloqueios) via servidor `research.ciatec.org` *(no Core, os parâmetros vêm do dado da fase; o servidor está em `ABD-1-Caique-api.md`)*
- §11.1, §5.3 — o mapa da cena tem de 6 a 24 intersecções, e o número delas define o tamanho da fábrica
- LAC-12, LG-Cai-09, LG-Cai-10 — o mapa de cada fase é o do arquivo de texto dela, escrito à mão, com desvios paralelos, igual em toda partida (o gerador por arquivo de texto é ideia do aluno, `Documentation/ideias-expansao.md`; orientador, 26/11/2026)
- §11.3 B.1, REQ-P2-04 — as Fases 1 e 2 têm 3 setores e 5 entregas, a Fase 2 tem fumaça a 50% (conforme a implementação do aluno), e a Fase 3 tem 5 setores e fumaça
- §4.4, LAC-12 — a fase marcada como treino (só a Fase 0) é a única exceção às faixas de setores e de entregas, com 2 setores e 2 entregas (conforme a implementação do aluno)
- REQ-P3-02 — a velocidade do robô vem do dado da fase
- §5.3, LA-12 — as entregas vêm do dado; intersecções, placas e setores vêm do arquivo de texto da fase

**Cenários de aceite:**

- Dado as Fases 1, 2 e 3, quando são carregadas em ordem, então setores e fumaça seguem o §11.3.
- Dado o arquivo de texto da Fase 1, quando a fase começa, então a fábrica gerada tem as paredes, as máquinas, os postes e os setores do arquivo, e o grafo do mapa tem as intersecções e os setores dele.
- Dado um arquivo com uma linha mais curta ou um caractere fora da legenda, quando a fase começa, então o Console aponta a linha e a coluna do erro, e nada é gerado.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-03.1.1 | Estender o `FaseDataSO`, que já tem velocidade, setores, entregas, fumaça, bloqueios e cena: a entrega que dispara a perturbação, o tempo de visibilidade das placas, a probabilidade de bloqueio e as faixas do §11.1, com a exceção de treino; dar à `Fase_01_Basica` e à `Fase_02_Fumaca` os campos novos, com os valores de hoje, e criar a `Fase_03` com os da LAC-12; e o campo `mapa` (TextAsset), o arquivo de texto da fábrica da fase (T-03.1.5) (visibilidade de 0 s nas Fases 2 e 3, LG-Cai-12) | 2 h · dados |
| T-03.1.5 | `LeitorDeMapa`, em C# puro: lê o arquivo de texto da fase — uma linha por fileira e um caractere por célula de 3 m; linha que começa por `;` é comentário — pela legenda `#` parede, `.` piso, `M` máquina, `+` intersecção com poste, `D` doca, `S` início, `1` a `6` setores (na ordem do `CorSetor`) e `b` trecho bloqueável, e devolve a grade das células; no erro de formato (linha de outro tamanho, caractere fora da legenda, sem `S` ou sem `D`), devolve a linha e a coluna dele; teste EditMode com um mapa pequeno e com cada erro | 2 h · dados |
| T-03.1.6 | `GeradorDeMapa`, no `Mapa_Fabrica` da Gameplay: antes do `GrafoDoMapa`, lê o `mapa` do dado da fase escolhida pelo `LeitorDeMapa` e instancia, a 3 m por célula, os prefabs de `Assets/Game/Prefabs/Mapa` pelos campos dele: `Tile_Floor` em toda célula andável, `Tile_Wall`, `Tile_Machine`, o `Poste` com o `Marker_Interesecao` no `+`, o `Marker_StartPoint` e o `Marker_RecoveryPoint` no `S`, o `Marker_Pacote` com o `PacoteColetavel` no `D` e o `Marker_SetorEntrega` com a cor do setor; com erro de formato, mostra no Console a linha e a coluna e não gera nada; um item do menu de contexto gera o mapa no Editor, sem Play; teste PlayMode: um mapa de 5×5 gera o número certo de pisos, paredes, postes e setores | 2 h · gameplay |
| T-03.1.2 | Escrever o arquivo de texto de cada uma das Fases 1 a 3 (`Assets/Game/Fases/Mapas/`; mapa fixo com desvios paralelos e as intersecções da LAC-12), com o `Mapa_Fabrica` de hoje (T-03.1.4) como molde da Fase 1, ligá-lo no campo `mapa` do dado e jogar cada fase; todas usam a cena Gameplay (`nomeCenaGameplay`) | 2 h · conteúdo |
| T-03.1.3 | O `FaseDataSO` (FaseDataS0.cs:7-26) com número, treino, velocidade, setores, entregas, fumaça, bloqueios e a cena da fase (`nomeCenaGameplay`), e os dados `Fase_01_Basica` (3 setores, 5 entregas, 3 m/s) e `Fase_02_Fumaca` (3 setores, 5 entregas, fumaça a 50%, 3,5 m/s) | já existe · dados |
| T-03.1.4 | O mapa montado à mão: o `Mapa_Fabrica` da cena Gameplay, com `Tile_Floor`, `Tile_Wall`, `Tile_Machine`, `Poste` e os `Marker_*` | já existe · conteúdo |

## 4.3.2 US-03.2 — As placas se escondem no meio da fase

**Perfil:** Pesquisador · **Horas:** 8 · **Prioridade:** P1 · **Milestone:** Core

**Depende de:** US-03.1, US-02.3

*Como pesquisador, quero que, depois de um começo limpo, parte das placas fique escondida por fumaça, sujeira, quebrada ou em manutenção, para que a criança precise lembrar o caminho e eu meça a recuperação de pista.*

**Requisitos do SGDD que ela realiza:**

- `RT-03` — Perturbação ambiental dinâmica (ocultação de placas por fumaça e bloqueio de corredores)
- `RT-04` — Fundo de tela 3D limpo/neutro (estilo cartoon sem distratores ou partículas piscantes)
- §11.1 — a ocultação cobre a placa com a opacidade do dado, de 0 a 100%
- §4.1, LG-Cai-12 — só as placas sorteadas ficam cobertas: até 1/3 das placas da fase, com opacidade de 50 a 100%
- §2.1, §4.1, LAC-25 — cada placa ocultada tem um tipo no dado — fumaça, sujeira, quebrada ou manutenção —, e nenhuma forma mostra a cor do setor quando a ocultação é total
- §10.2 Visual — fumaça, sujeira, placa quebrada e manutenção são estáticas, sem partícula nem piscar
- LAC-20 — a fumaça não impede o robô de passar
- §5.2, GP-03, LG-Cai-12 — cada fase começa sem perturbação; a da fase entra depois da entrega definida no dado (padrão 3), só nas Fases 2 a 5, e a Fase 1 não muda durante a partida
- GP-08 — a perturbação entra aos poucos (a fumaça sobe em pelo menos 2 s), sem mudança brusca
- REQ-P3-02 — esgotado o tempo de visibilidade da placa, ela passa a ficar coberta

**Cenários de aceite:**

- Dado o início da Fase 3, quando a fase começa, então nenhuma placa está coberta; e, depois da 3ª entrega, a fumaça sobe nas placas sorteadas.
- Dado uma placa com fumaça a 100%, quando o robô chega à intersecção, então a cor da placa não se vê; a 50%, ela se vê pela metade, sem piscar.
- Dado uma placa em manutenção, quando o robô chega, então aparece o ícone neutro no lugar dela, sem cor.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-03.2.1 | `OcultacaoDaPlaca` e o tipo de ocultação por placa no dado (fumaça, sujeira, quebrada, manutenção): aplica a opacidade (0–100%) à camada do campo `camadaFumaca` e troca o visual pelo tipo, pelos campos `visualSujeira`, `visualQuebrada` e `visualManutencao`, sem partícula nem piscar | 2 h · presentation |
| T-03.2.2 | Sorteio em C# puro das placas ocultadas, entre as elegíveis do dado: até 1/3 das placas, opacidade de 50 a 100%, pela semente e pelo `densidadeFumaca` que o `FaseDataSO` já tem (FaseDataS0.cs:21); o tempo de visibilidade cobre a placa depois da exposição; teste EditMode | 2 h · gameplay |
| T-03.2.3 | O gatilho da perturbação no dado: entra depois da N-ª entrega (padrão 3), aos poucos (pelo menos 2 s), só nas Fases 2 a 5; teste PlayMode: a Fase 3 começa limpa, e a fumaça entra depois da 3ª entrega | 2 h · gameplay |
| T-03.2.4 | Os visuais estáticos no prefab da placa — a camada de fumaça (material sem partícula), a sujeira, a placa caída e sem cor e o ícone neutro de ferramenta —, ligados aos campos da `OcultacaoDaPlaca` | 2 h · arte |

## 4.3.3 US-03.3 — Corredores bloqueados, e as Fases 4 e 5

**Perfil:** Pesquisador · **Horas:** 8 · **Prioridade:** P1 · **Milestone:** Core

**Depende de:** US-03.1, US-03.2

*Como pesquisador, quero bloquear de 0 a 3 corredores, por obra, reforma ou multidão, e ter as Fases 4 (bloqueio) e 5 (combinada), para que a criança recalcule a rota e eu meça a flexibilidade cognitiva.*

**Requisitos do SGDD que ela realiza:**

- `RT-03` — Perturbação ambiental dinâmica (ocultação de placas por fumaça e bloqueio de corredores)
- `RT-09` — Eliminação total de alarmes de erro, buzinas e timbres estridentes em falhas
- §11.1 — a fase bloqueia de 0 a 3 corredores, conforme o dado
- LG-Cai-09 — numa fase com bloqueio há ao menos 1, sorteado com probabilidade 0,5 por trecho bloqueável, e com 3 bloqueios ainda existe rota até cada setor
- §4.2 B — diante do bloqueio, o robô desacelera suavemente até parar, sem atravessá-lo, e esbarrar nele toca um som sutil de obstrução, de baixa frequência, ou nenhum
- §2.1, §4.1, LAC-25 — cada bloqueio tem um tipo no dado — obra, reforma ou multidão —, com a mesma colisão e a mesma desaceleração, e nenhuma forma se mexe nem pisca
- §9.2 REQ-P2-04, §11.3 B.1 — a Fase 4 tem bloqueio sem fumaça, e a Fase 5 tem os dois

**Cenários de aceite:**

- Dado um corredor bloqueado por obra, quando o robô chega a ele, então vê o cavalete e desacelera suavemente até parar; com a multidão, vê as silhuetas paradas e desacelera do mesmo jeito.
- Dado 3 corredores bloqueados, quando o robô procura um setor, então existe rota até ele, pelos desvios paralelos do arquivo da fase.
- Dado a Fase 4 carregada, então ela tem bloqueio e não tem fumaça; dado a Fase 5, tem os dois.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-03.3.1 | `TrechoBloqueavel`, que o `GeradorDeMapa` põe em cada `b` do arquivo da fase, e o sorteio em C# puro: o obstáculo cai nos trechos sorteados pela semente e pela probabilidade da fase (0,5 por trecho, mínimo 1), até o `quantidadeBloqueios` (FaseDataS0.cs:23), instanciado do campo `prefabBloqueio`; teste com os dados das Fases 4 e 5 montados por código | 2 h · gameplay |
| T-03.3.2 | Desaceleração suave diante do obstáculo, sem atravessá-lo, e o clipe do campo `somObstrucao` do `RoboController`; o som provisório de obstrução, sutil e grave | 2 h · gameplay |
| T-03.3.3 | O tipo de bloqueio no dado (obra, reforma, multidão) e os campos `prefabObra`, `prefabReforma` e `prefabMultidao` no `TrechoBloqueavel`; os três prefabs provisórios (cavalete; pilha de caixas com um cone; silhuetas paradas e arredondadas, sem rosto nem animação), estáticos e com o mesmo colisor | 2 h · arte |
| T-03.3.4 | Os dados das Fases 4 e 5, com os valores da LAC-12, a probabilidade de bloqueio 0,5 e a visibilidade de 10 s na Fase 5 (LG-Cai-12); escrever o arquivo de texto de cada uma (desvios paralelos e um `b` em cada trecho bloqueável) e ligá-lo no campo `mapa` do dado | 2 h · conteúdo |

## 4.4 EP-04 — Fim, pausa e registro da sessão

**Milestone:** Core

O fim da fase e a conclusão que avança, o teto de tempo, a pausa com as configurações sensoriais, os eventos e as amostras, o arquivo local com o código do participante, e o marco do Core.

**Por que importa:** É o que fecha o loop para a criança e o que o pesquisador leva da sessão.

**Pronto quando:**

- O marco US-04.5 foi jogado na build de PC, do menu ao fim das Fases 1 a 5;
- O arquivo de cada sessão bate com o que foi jogado.

## 4.4.1 US-04.1 — A fase termina, e a seguinte começa

**Perfil:** Criança · **Horas:** 6 · **Prioridade:** P1 · **Milestone:** Core

**Depende de:** US-02.3

*Como criança, quero que a fase termine de um jeito claro, com as minhas entregas na tela e um botão para a próxima, sem cronômetro nem castigo, para que eu termine com uma sensação boa e siga em frente.*

**Requisitos do SGDD que ela realiza:**

- `RT-17` — Tempo máximo de cada fase entre 20 a 30 minutos (programável) *(no Core, o teto é o padrão de 20 min, fixo; programável na Expansão)*
- `RT-19` — Definição e aplicação de critérios explícitos para interrupção de protocolo longitudinal
- §7.1, §10.3-4, LAC-07 — a fase termina ao completar o número de entregas do dado e carrega a cena `Results`, a Tela de Conclusão (conforme a implementação do aluno)
- §13A H-04 — o fim grava o motivo (entregas ou teto)
- REQ-P2-03, §11.1, §11.3 A, LAC-08 — a tentativa (uma entrega) que passa do tempo-alvo — no Core, os 45 s do Suporte 1 — é marcada na telemetria, sem nada na tela
- §11.2, §7.1, LAC-08 — a sessão encerra ao bater o teto, com a conclusão positiva, sem tela punitiva, e grava o evento `session_time_cap_reached` com o motivo `teto_de_tempo` e o valor do teto; o relógio não corre na pausa
- LG-Cai-17 — com o teto batido no meio de uma entrega, a sessão espera a entrega terminar e só então encerra
- §10.1, REQ-P2-03 — nenhum cronômetro aparece
- §10.3-4, LG-Cai-23 — a conclusão mostra, de forma positiva e curta, as entregas feitas em caixinhas, sem número nem texto
- §10.3-4, LG-Cai-06, LAC-19 — um botão leva direto à próxima partida, sem tela intermediária, e o ícone dele muda quando ela é de outra fase; no Core, a próxima é a fase seguinte, e a Fase 5 se repete
- §10.1 — nada de vermelho, alarme ou "Game Over"

**Cenários de aceite:**

- Dado a última entrega da Fase 2, quando ela acontece, então a cena `Results` abre com as caixinhas, e o botão de avanço mostra o ícone de fase nova e abre a Fase 3.
- Dado o teto atingido com o robô levando uma caixa, quando a criança entrega, então a sessão encerra na conclusão, e o evento `session_time_cap_reached` é gravado.
- Dado o jogo em pausa por 5 min, quando ele retoma, então o relógio da sessão não andou.
- Dado a Fase 5 terminada, quando a conclusão abre, então o botão mostra o ícone da mesma fase, e tocá-lo abre a Fase 5 de novo.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-04.1.1 | Tirar para C# puro a regra de fim de fase que já existe (CicloEntregaManager.cs:61-65), com o motivo (entregas ou teto); os relógios de tentativa e de sessão, pelo `Agentes.Relogio`, com o tempo-alvo do Suporte 1 (45 s) e o teto de 20 min fixos no Core, parados na pausa, e o aviso de tentativa acima de 30 s, que a `SetaGuia` usa; teste EditMode | 2 h · gameplay |
| T-04.1.2 | Ao bater o teto, a entrega em curso termina (LG-Cai-17); então a sessão encerra, grava `session_time_cap_reached` com `teto_de_tempo` e o valor, e abre a conclusão positiva; teste PlayMode com teto curto, em que a pausa não conta | 2 h · gameplay |
| T-04.1.3 | `TelaDeConclusao` na cena `Results`, que a fase já carrega: as entregas da fase (lidas pelo `GameManager`) em caixinhas e o botão de avanço, que troca de ícone quando a próxima partida é de outra fase (campos `areaEntregas`, `botaoAvancar`, `iconeMesmaFase` e `iconeFaseNova`); no Core, a próxima é a fase seguinte, guardada no `GameManager`, e a Fase 5 se repete; montar a tela sem texto, com os dois ícones; teste PlayMode do fim da fase à fase seguinte | 2 h · presentation |
| T-04.1.4 | A fase termina quando o `entregasConcluidas` chega ao `entregasParaVencer` do dado (CicloEntregaManager.cs:20-27, :61-65) e carrega a cena `Results` (:64) | já existe · gameplay |

## 4.4.2 US-04.2 — Pausar, ajustar o som e sair

**Perfil:** Terapeuta · **Horas:** 6 · **Prioridade:** P1 · **Milestone:** Core

**Depende de:** US-02.3

*Como terapeuta, quero pausar o jogo na hora, ajustar ou desligar a música mantendo os efeitos, e que o ajuste continue valendo na próxima vez, para que eu interrompa diante de sinais de sobrecarga e a criança com hipersensibilidade auditiva jogue sem desconforto.*

**Requisitos do SGDD que ela realiza:**

- `RT-07` — Controle de volume independente para música de fundo (BGM) e efeitos sonoros (SFX)
- `RT-08` — Opção de desativação total da BGM mantendo apenas SFX de ação ativos
- `RT-18` — Atalho de pausa e botão de interrupção de emergência de sessão pelo terapeuta *(aqui, a pausa; o atalho do mediador e a interrupção de emergência são da US-06.1)*
- §10.3-3, LG-Cai-16 — a pausa abre pelo botão de pausa e pelo Esc e congela o jogo na hora, numa sobreposição limpa e semitransparente
- §10.3-3 — a pausa oferece [Continuar], [Reiniciar Fase], [Configurações Sensoriais] e [Sair], em ícones
- §10.3-3, LG-Cai-16 — [Reiniciar Fase] recomeça a fase com o mesmo dado, e [Sair] volta ao menu sem passar pela Tela de Conclusão
- §11.1 — cada volume vai de mudo a 100% (o §11.1 dá a faixa de 0 a 70 dB)
- §10.3-3 — o painel de configurações abre pelo menu e pela pausa
- §10.2 Auditivo, LAC-31 — os volumes, a música ligada ou desligada, a paleta, o esquema de controle e a sensibilidade valem do menu ao jogo e entre sessões: fechar e reabrir o jogo mantém o valor

**Cenários de aceite:**

- Dado o robô andando, quando o botão de pausa é tocado, então o robô para e a pausa aparece; [Continuar] segue de onde parou.
- Dado o jogo em pausa pelo Esc, quando [Sair] é tocado, então o menu abre, sem a Tela de Conclusão.
- Dado a música desligada, quando uma entrega acontece, então o SFX de acerto toca.
- Dado a música em 20%, quando o jogo é fechado e aberto de novo, então ela continua em 20%.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-04.2.1 | `MenuDePausa`: congela o tempo e a entrada e abre pelo botão de pausa e pelo Esc (campos `painel`, `botaoContinuar`, `botaoReiniciar`, `botaoConfiguracoes`, `botaoSair` e `painelOptions`); na Gameplay, a sobreposição semitransparente com os quatro botões em ícone, e um prefab do painel de opções da cena Menu (com o `PainelOptionsUI`), que [Configurações Sensoriais] abre | 2 h · presentation |
| T-04.2.2 | [Reiniciar Fase] recomeça com o mesmo dado e grava o evento; [Sair] volta ao menu sem passar pela conclusão (LG-Cai-16); teste PlayMode: pausar pelo botão e pelo Esc congela, continuar retoma, reiniciar recomeça e sair volta ao menu | 2 h · gameplay |
| T-04.2.3 | Gravar e ler entre sessões, no `SettingsManager`, os campos que já existem (`audio_volume`, `bgm_volume`, `bgm_enabled`, `paletaCoresIndex`, `control_scheme` e `input_gain_*`), num armazenamento local que os outros ajustes reaproveitam; teste da ida e volta, e de que o volume ajustado no menu vale no Gameplay | 2 h · dados |
| T-04.2.4 | Volumes independentes de música e de efeitos, e a música desligável, pelos parâmetros `BGMVolume` e `SFXVolume` do `MainAudioMixer` (`AtualizarVolumesNoMixer`, SettingsManager.cs:53-66), com os controles no `PainelOptionsUI` (:36-53) | já existe · presentation |
| T-04.2.5 | O `SettingsManager` atravessa a troca de cena (singleton com `DontDestroyOnLoad`, SettingsManager.cs:35-46) | já existe · dados |

## 4.4.3 US-04.3 — Cada decisão da criança vira um registro

**Perfil:** Pesquisador · **Horas:** 6 · **Prioridade:** P1 · **Milestone:** Core

**Depende de:** US-02.3, US-03.2, US-03.3, US-04.2

*Como pesquisador, quero que cada decisão da criança vire um evento com o tempo, e que a posição, a orientação e a velocidade do robô sejam amostradas, para que eu calcule depois a hesitação nas intersecções, a eficiência de rota e a suavidade.*

**Requisitos do SGDD que ela realiza:**

- `RT-15` — Registro contínuo e silencioso de biomarcadores (hesitação, eficiência e suavidade de rota)
- §3.2, LAC-21 — chegar a uma intersecção e escolher a direção geram um evento cada; coletar, tentar entregar (com o setor tentado e o esperado, sem marcar certo ou errado) e entregar também
- LAC-21 — encontrar placa ocultada e encontrar bloqueio (com o tipo) e dar ré geram um evento cada; início e fim de sessão e de fase, pausa e retomada também
- §3.2 — todo evento leva o tempo desde o início da partida (`offset_ms`), nunca o horário do relógio
- §3.2, LG-Cai-19 — posição, orientação, velocidade e entrada ativa são amostradas, 10 vezes por segundo, e a amostragem para na pausa e no fim de fase
- §8 linha 4 — nada da coleta aparece na tela

**Cenários de aceite:**

- Dado o robô se aproximando de um cruzamento, quando chega a ele e vira à direita, então ficam gravados a chegada e a direção, com o tempo de cada uma.
- Dado a caixa azul da vez, quando o robô entra no setor verde, então fica gravada a tentativa, com o setor tentado e o esperado.
- Dado 10 s de partida, quando a fase está rodando, então há cerca de 100 amostras; e, em 5 s de pausa, nenhuma.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-04.3.1 | Registrador de eventos em C# puro, com o `offset_ms` desde o início, e teste EditMode; ligar os eventos de navegação e de entrega da LAC-21: chegar à intersecção, escolher a direção, dar ré, coletar, tentar entregar (com o setor tentado e o esperado) e entregar | 2 h · telemetria |
| T-04.3.2 | Ligar os eventos de sessão, de fase, de pausa e de retomada e os de perturbação (`sign_occluded_encountered` e `corridor_blocked_encountered`, com o tipo); teste PlayMode: uma partida curta grava a sequência esperada | 2 h · telemetria |
| T-04.3.3 | Amostragem de posição, orientação, velocidade e entrada, 10 vezes por segundo, só com a fase rodando; teste PlayMode: 10 s de partida dão cerca de 100 amostras, e a pausa não dá nenhuma | 2 h · telemetria |

## 4.4.4 US-04.4 — A sessão fica gravada num arquivo, com o código do participante

**Perfil:** Pesquisador · **Horas:** 6 · **Prioridade:** P1 · **Milestone:** Core

**Depende de:** US-04.3, US-04.2, US-01.2

*Como pesquisador, quero que tudo seja gravado num arquivo no computador durante a sessão, com o código do participante digitado no menu, para que nada se perca e cada sessão diga de quem é, sem dado pessoal.*

**Requisitos do SGDD que ela realiza:**

- `RT-15` — Registro contínuo e silencioso de biomarcadores (hesitação, eficiência e suavidade de rota)
- §13, LAC-14 — eventos e amostras são gravados num arquivo local por sessão enquanto se joga, e fechar o jogo no meio da fase não perde o que já foi gravado
- LAC-14, LAC-21 — o formato do arquivo (um registro por linha em JSON, os campos, os tipos e as unidades de cada evento e amostra) está documentado no repositório
- decisão do orientador, 26/11/2026 — toda sessão gravada traz o código do participante, sem nome nem dado pessoal; o código se digita num campo do menu, aceita só letras, números, `-` e `_` (até 16) e vale nas sessões seguintes até ser trocado

**Cenários de aceite:**

- Dado uma fase jogada até o fim, quando o arquivo é aberto, então ele tem os eventos e as amostras da fase.
- Dado o jogo fechado no meio da fase, quando o arquivo é aberto, então ele tem tudo até o momento do fechamento.
- Dado o código `P07` digitado no menu, quando a Fase 1 é jogada, então cada registro do arquivo traz `P07`.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-04.4.1 | Gravar eventos e amostras incrementalmente num arquivo por sessão, um registro JSON por linha; teste: fechar no meio da fase mantém o que já foi gravado | 2 h · telemetria |
| T-04.4.2 | O campo do código do participante no menu (`campoCodigoParticipante` no `MenuPrincipalController`): a regra em C# puro aceita só letras, números, `-` e `_`, até 16, com teste EditMode; o código fica no `GameManager` e entre sessões, pelo caminho da T-04.2.3; na cena Menu, o campo de texto com um ícone, sem rótulo | 2 h · presentation |
| T-04.4.3 | Gravar o código do participante em toda a telemetria, com o teste; documentar no repositório o formato do arquivo da sessão (os campos, os tipos e as unidades de cada evento e amostra), com um exemplo | 2 h · telemetria |

## 4.4.5 US-04.5 — Marco Core: do menu ao fim das Fases 1 a 5, no PC

**Perfil:** Terapeuta · **Horas:** 2 · **Prioridade:** P1 · **Milestone:** Core · **história de marco Core**

**Depende de:** todas as outras histórias do Core.

*Como terapeuta, quero abrir a build de PC e jogar do menu ao fim das Fases 1 a 5, para que eu veja o jogo de verdade — o loop, as perturbações e a telemetria —, e não só peças.*

**Cenários de aceite:**

- Dado a build de PC aberta, quando o Caique digita o código do participante, escolhe a Fase 1 no seletor do menu e segue pelo botão de avanço até a Fase 5, então cada fase termina na conclusão, com a seta-guia, as placas escondidas e os bloqueios, e cada sessão tem o seu arquivo local.
- Dado o arquivo de uma sessão jogada, quando o Caique o abre, então as entregas, as tentativas erradas, as pausas e o fim da fase que ele jogou estão nos eventos, e as amostras cobrem a partida.
- Dado a mesma sessão, quando o `Player.log` é aberto, então não há exception.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-04.5.1 | Gerar a build de PC, jogá-la do menu ao fim das Fases 1 a 5 (da Fase 1 escolhida no seletor à 5 pelo botão de avanço) e conferir no arquivo de cada sessão os eventos e as amostras contra o que foi jogado | 2 h · build |

## 4.5 EP-05 — O tutorial da Fase 0

**Milestone:** Expansão

A Fase 0: uma fábrica pequena e sem pressa, em 12 etapas com uma novidade cada, a demonstração do robô e, ligável, a instrução em Libras.

**Por que importa:** Ensina sem texto (RT-10), e cada obstáculo aparece isolado antes de aparecer no jogo.

**Pronto quando:**

- A primeira sessão do participante passa pela Fase 0;
- As 12 etapas rodam na ordem, e nenhuma tem texto.

## 4.5.1 US-05.1 — Treinar na Fase 0, uma coisa de cada vez

**Perfil:** Criança · **Horas:** 6 · **Prioridade:** P1 · **Milestone:** Expansão

**Depende de:** US-02.4, US-03.2, US-03.3

*Como criança, quero treinar numa fábrica pequena e sem pressa, praticando uma coisa de cada vez, para que eu aprenda antes de jogar e conheça cada obstáculo antes de ele aparecer no jogo.*

**Requisitos do SGDD que ela realiza:**

- `RT-10` — Onboarding prático na Fase 0 exclusivamente por animação e demonstração visual (sem texto)
- §4.4 — a Fase 0 não tem pressão de tempo, vidas nem pontuação punitiva, e a fábrica dela é menor que a da Fase 1
- §4.4, §7.1, §10.3-1 — o [Tutorial] do menu abre a Fase 0 a qualquer momento
- §4.3, §11.3 A, LAC-19 — a primeira sessão do participante começa pela Fase 0
- LG-Cai-02 — na Fase 0, a seta-guia aponta em todas as entregas
- §4.4, §5.2, §7.1, LG-Cai-15 — a Fase 0 apresenta, isoladas e nesta ordem, 12 etapas — mover, girar, coletar, seguir a placa, entregar e os sete obstáculos (fumaça, sujeira, placa quebrada, placa em manutenção, obra, reforma e multidão) —, e cada etapa traz uma novidade só
- sugestões §1.3 — cada etapa concluída grava um evento de etapa

**Cenários de aceite:**

- Dado [Tutorial] tocado, quando a Fase 0 abre, então não há relógio, vidas nem pontuação punitiva, e a seta aponta em todas as entregas.
- Dado a etapa de fumaça, quando a criança chega a ela, então só a fumaça é nova, e, ao terminar, o evento de etapa é gravado.
- Dado a Fase 0 inteira, quando percorrida, então cada uma das sete formas de obstáculo aparece numa etapa só dela.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-05.1.1 | A primeira sessão do participante passa pela Fase 0 (o [Tutorial] já a abre, pelo `faseTutorialPadrao`); o `Fase_00_Tutorial` recebe os campos novos do `FaseDataSO` (sem tempo-alvo; o teto de segurança vale); na fase de treino, a `SetaGuia` aponta em todas as entregas; teste PlayMode: a Fase 0 não tem relógio nem pontuação punitiva, e a seta aponta em todas as entregas | 2 h · gameplay |
| T-05.1.2 | A sequência de etapas da Fase 0 (ScriptableObject), com a condição de conclusão de cada etapa e o evento `tutorial_step_completed`; teste PlayMode das 12 etapas | 2 h · gameplay |
| T-05.1.3 | Cada etapa ativa só a novidade dela, pelos objetos do campo `objetosDaEtapa`; criar o asset da sequência com as 12 etapas na ordem e montar na cena da Fase 0 os objetos de cada etapa (as placas ocultadas e os bloqueios), ligados | 2 h · conteúdo |
| T-05.1.4 | O `Fase_00_Tutorial`, de treino, com 2 setores, 2 entregas e 2,5 m/s, ligado ao `faseTutorialPadrao` do `GameManager` na cena Menu, e a cena com os setores azul e verde | já existe · dados |

## 4.5.2 US-05.2 — Ver o robô mostrar cada etapa, também em Libras

**Perfil:** Criança · **Horas:** 8 · **Prioridade:** P1 · **Milestone:** Expansão

**Depende de:** US-05.1

*Como criança, quero ver o robô fazendo o que devo fazer em cada etapa e, se eu me comunico em Libras, a instrução também em Libras, para que eu entenda sem ler.*

**Requisitos do SGDD que ela realiza:**

- `RT-10` — Onboarding prático na Fase 0 exclusivamente por animação e demonstração visual (sem texto)
- §4.4, REQ-P1-01 — cada etapa da Fase 0 mostra uma animação curta em loop da ação, com ícones concretos e placas coloridas, que some quando a criança faz a ação
- §10.2 Linguístico, §7.2 — a Fase 0 inteira não tem texto explicativo
- §3A GP-01, LAC-23 — com a opção de Libras ligada (desligada por padrão), cada etapa mostra o vídeo em Libras dela, num canto, sem cobrir o robô nem as placas; desligada, a janela não aparece

**Fora do backlog (evento externo):** gravar os vídeos com um intérprete de Libras; até lá, valem os do intérprete desenhado provisório (LG-Cai-20).

**Cenários de aceite:**

- Dado uma etapa da Fase 0, quando ela começa, então uma animação curta em loop mostra a ação, sem texto.
- Dado a opção de Libras ligada, quando uma etapa começa, então o vídeo dela toca no canto; desligada, nenhuma janela aparece.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-05.2.1 | `TocadorDeDemonstracao`: mostra a demonstração da etapa e some quando a criança faz a ação (campos `janela` e `demonstracoes`, etapa → clipe); pô-lo num canto do HUD da Fase 0 e ligar as animações às etapas | 2 h · presentation |
| T-05.2.2 | As animações-demonstração do robô das cinco ações: mover, girar, coletar, seguir a placa e entregar | 2 h · arte |
| T-05.2.3 | As animações-demonstração dos sete obstáculos: fumaça, sujeira, placa quebrada, placa em manutenção, obra, reforma e multidão | 2 h · arte |
| T-05.2.4 | `JanelaLibras`: toca o vídeo da etapa no campo `player`, pela lista etapa → vídeo, com a chave `librasLigada` no `SettingsManager`, desligada por padrão; teste PlayMode ligada e desligada; pôr a janela num canto do HUD da Fase 0, com os vídeos provisórios (intérprete desenhado) e a chave nas configurações | 2 h · presentation |

## 4.6 EP-06 — O mediador, os perfis e os ajustes sensoriais

**Milestone:** Expansão

O painel do mediador (calibrar, liberar fase, interromper com motivo), os presets por perfil, os parâmetros da partida recebidos por uma interface (a adaptação é do backend), a paleta restrita e o brilho.

**Por que importa:** É o que deixa o terapeuta conduzir a sessão de cada criança sem mexer no código.

**Pronto quando:**

- O mediador calibra e interrompe pelo painel;
- O perfil aplica o preset, e o arquivo da sessão traz os parâmetros recebidos.

## 4.6.1 US-06.1 — O mediador calibra e interrompe a sessão pelo painel

**Perfil:** Terapeuta · **Horas:** 8 · **Prioridade:** P1 · **Milestone:** Expansão

**Depende de:** US-01.2, US-03.1, US-04.1, US-04.2

*Como terapeuta, quero ajustar os parâmetros da fase no próprio jogo, liberar uma fase e pausar e encerrar a sessão por um atalho, escolhendo o motivo, para que eu calibre a sessão sem o painel do servidor e pare na hora diante de sobrecarga.*

**Requisitos do SGDD que ela realiza:**

- `RT-13` — Recepção de parâmetros de fase (velocidade, fumaça, bloqueios) via servidor `research.ciatec.org` *(aqui, a calibração local; o servidor está em `ABD-1-Caique-api.md`)*
- `RT-18` — Atalho de pausa e botão de interrupção de emergência de sessão pelo terapeuta
- `RT-19` — Definição e aplicação de critérios explícitos para interrupção de protocolo longitudinal
- REQ-P3-02 — o painel ajusta a velocidade do robô, o tempo de visibilidade das placas, a densidade da fumaça e a probabilidade de bloqueio, e o valor salvo vale na fase seguinte
- §2.3, §5.3, LG-Cai-08, LA-12 — o painel escolhe o participante e o perfil (padrão Suporte 1) e ajusta as entregas; intersecções, placas e setores vêm do arquivo de texto de cada fase
- LG-Cai-07, §11.2 — o painel libera uma fase para o participante, também uma anterior (sinais de frustração)
- §11.1 — o painel recusa valores fora das faixas
- REQ-P3-02, LG-Cai-03 — a velocidade vem da configuração local quando ela existe, e do dado da fase quando não; um valor fora de 0,5 a 2 vezes a velocidade padrão é recusado, e vale o da fase
- REQ-P3-03, LAC-18 — o atalho (F10, ou segurar o botão de pausa por 3 s) pausa na hora e abre o painel do mediador, e o clique curto da criança não o abre
- REQ-P3-03 — [Interromper sessão] encerra a sessão, grava o evento de interrupção e salva o arquivo
- §11.2 — ao interromper, o terapeuta escolhe o motivo — fadiga, desconforto visual, confusão sobre a tarefa ou evento adverso —, em ícones, e o evento traz o motivo e o tempo
- §11.2, LAC-08 — o encerramento pelo teto é o da US-04.1 (o mesmo evento, o mesmo motivo, o valor da configuração), e o painel o mostra ao lado dos motivos manuais

**Cenários de aceite:**

- Dado a fumaça ajustada para 30% no painel, quando a próxima fase com fumaça começa, então a fumaça está em 30%; e 40 entregas digitadas são recusadas.
- Dado a sessão em andamento, quando o terapeuta aciona o atalho, interrompe e escolhe "fadiga", então a sessão encerra, e o evento grava o motivo e o tempo.
- Dado a criança jogando, quando ela clica rápido no botão de pausa, então abre só a pausa, e não o painel.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-06.1.1 | `PainelDoMediador`: o participante, o perfil (padrão Suporte 1), liberar a fase e os parâmetros do REQ-P3-02 e do §5.3, cada um num campo; montá-lo num Canvas próprio, com os controles, e ligar os campos | 2 h · presentation |
| T-06.1.2 | Gravar a configuração editada num arquivo local, recusando o que sai das faixas do §11.1 — e a velocidade fora de 0,5× a 2× a do dado —, com a prioridade configuração > dado da fase sobre a leitura que já existe (RoboController.cs:28-31); teste: o valor editado vale na fase seguinte, e o fora da faixa é recusado | 2 h · dados |
| T-06.1.3 | O atalho do mediador (F10; segurar a pausa por 3 s), que pausa e abre o painel; [Interromper sessão] (campo `botaoInterromper`, com ícone) encerra, grava `session_interrupted_by_mediator` e salva o arquivo; teste PlayMode: o atalho encerra, e o clique curto não abre o painel | 2 h · gameplay |
| T-06.1.4 | Os motivos da interrupção (fadiga, desconforto visual, confusão, evento adverso) em quatro botões com ícone (campo `botoesMotivo`), gravados com o tempo, e o encerramento pelo teto da US-04.1 mostrado ao lado, sem relógio novo; teste: cada motivo é gravado com o tempo, e o teto aparece com o evento dele | 2 h · presentation |

## 4.6.2 US-06.2 — O perfil da criança ajusta o jogo

**Perfil:** Terapeuta · **Horas:** 5 · **Prioridade:** P1 · **Milestone:** Expansão

**Depende de:** US-06.1, US-06.4, US-05.1

*Como terapeuta, quero escolher o perfil da criança, para que a faixa de fases, as perturbações, o sensorial, a paleta e a variante da Fase 0 respeitem o nível de suporte dela.*

**Requisitos do SGDD que ela realiza:**

- `RT-05` — Menu para seleção e restrição de paletas de cores (prevenção de aversão/hiperfoco por cores)
- §11.3 A, B.1 — o Suporte 1 joga as Fases 1 a 5, com fumaça de 0 a 100% e até 3 bloqueios, entrando pela Fase 0 rápida
- §11.3 B.2 — o Suporte 2 fica nas Fases 1 a 3, com fumaça até 50%, a Fase 4 desligada, a música desligada, os efeitos ligados e a paleta pré-ajustada
- §11.3 B.3 — o Suporte 3 joga as Fases 0 e 1 simplificadas, com 3 setores de cores primárias, placas 100% visíveis, sem fumaça nem bloqueio
- §11.3 A, LAC-08 — o tempo-alvo da tentativa é 45 s no Suporte 1, 30 s no Suporte 2 e nenhum no Suporte 3
- LG-Cai-08 — sem perfil escolhido no painel, vale o Suporte 1
- §11.3 A, B, LG-Cai-15 — a variante da Fase 0 segue o perfil: a rápida (Suporte 1) faz cada etapa uma vez e avança sozinha; a guiada (Suporte 2), duas vezes, e avança pela tecla F9 do mediador; a estendida (Suporte 3) faz só mover e entregar, sem obstáculos, e repete até o mediador encerrar

**Fora do backlog (evento externo):** no Suporte 3, a sessão é feita com mediação física (mão sobre mão ou bastões de direção, §11.3 B.3); no Suporte 2, o mediador faz a demonstração guiada da Fase 0 (§11.3 B.2).

**Cenários de aceite:**

- Dado o perfil Suporte 2, quando a sessão começa, então a fumaça fica em até 50%, a Fase 4 fica desligada, a música vem desligada e placas e setores usam a paleta pré-ajustada.
- Dado o perfil Suporte 3, quando a sessão começa, então há 3 setores de cores primárias, sem fumaça nem bloqueio, e o tutorial abre na variante estendida.
- Dado nenhum perfil escolhido, quando a sessão começa, então vale o Suporte 1, com a Fase 0 rápida.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-06.2.1 | `PresetDePerfil` (ScriptableObject): a faixa de fases, os tetos de perturbação, o tempo-alvo da tentativa (0 = nenhum), o sensorial, a paleta e a variante da Fase 0; aplicar o preset do perfil escolhido ao começar a sessão (sem escolha, o Suporte 1); teste EditMode: cada preset dá os valores do §11.3 B | 2 h · dados |
| T-06.2.2 | Os assets Suporte1, Suporte2 (com a paleta pré-ajustada) e Suporte3, com os valores do §11.3, ligados ao campo `presets` do `PainelDoMediador` | 1 h · dados |
| T-06.2.3 | As variantes da Fase 0 (rápida, guiada, estendida) e a escolha pelo perfil; na guiada, a etapa avança pela tecla F9 do mediador; os três assets de variante, ligados aos presets; teste EditMode: perfil → variante | 2 h · gameplay |

## 4.6.3 US-06.3 — A partida recebe os parâmetros de fora e grava o que recebeu

**Perfil:** Terapeuta · **Horas:** 4 · **Prioridade:** P1 · **Milestone:** Expansão

**Depende de:** US-06.1, US-06.2, US-04.4

*Como terapeuta, quero que o jogo receba de fora a fase e os parâmetros de cada partida e grave o que recebeu, para que a regra de adaptação rode num lugar só, o backend do CIATEC, e cada sessão diga com que parâmetros foi jogada.*

**Requisitos do SGDD que ela realiza:**

- `RT-13` — Recepção de parâmetros de fase (velocidade, fumaça, bloqueios) via servidor `research.ciatec.org`
- `RT-14` — Regressão silenciosa de dificuldade (redução de perturbação) sem telas de "Game Over" *(a regra roda no backend; no jogo, a interface que aplica e grava o que recebe, sem tela de "Game Over")*
- §12, LAC-22 — a partida começa com os parâmetros que a interface devolveu, e não com os lidos direto do dado da fase; sem rede, o provedor local devolve o preset da fase, com o perfil e a calibração do mediador, e não muda nada pelo desempenho
- §11.1 — parâmetros fora das faixas são recusados: vale o preset da fase, e o erro é gravado
- sugestões §1.3 — o registro da sessão grava o evento `session_parameters_received`, com os valores e a origem (local ou backend)
- §10.3-4, LG-Cai-06 — a fase que o provedor devolve é a da próxima partida que o botão de avanço da conclusão abre
- §11.1 nota — um provedor de teste com outros valores muda a partida sem mudar a lógica do jogo

**Cenários de aceite:**

- Dado o provedor local e a Fase 2 escolhida, quando a partida começa, então a fumaça é a do dado da Fase 2 com o preset do perfil, e o evento `session_parameters_received` traz esses valores, com a origem local.
- Dado três partidas seguidas com 100% de acerto, quando a próxima começa pelo provedor local, então a fase e os parâmetros são os mesmos.
- Dado um provedor que devolve 40 entregas, quando a partida começa, então vale o preset da fase, e o erro é gravado.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-06.3.1 | A interface `IProvedorDeParametros` e o tipo `ParametrosDaPartida` (fase, velocidade, densidade da fumaça, tempo de visibilidade, probabilidade de bloqueio, entregas, tempo-alvo e origem), e o `ProvedorLocalDeParametros`: devolve o dado da fase com o preset do perfil e a calibração do painel, sem regra de desempenho, e a fase é a escolhida no menu, a liberada pelo mediador ou a da partida anterior; em C# puro, com teste EditMode | 2 h · dados |
| T-06.3.2 | Ao começar a partida, pedir os parâmetros ao provedor e aplicá-los no lugar da leitura direta do `FaseDataSO`, recusar o que sai das faixas (vale o preset, e o erro é gravado) e gravar `session_parameters_received`, com os valores e a origem; testes: um provedor de teste muda a partida, e o local não muda com o desempenho | 2 h · gameplay |

## 4.6.4 US-06.4 — Restringir as cores e baixar o brilho

**Perfil:** Terapeuta · **Horas:** 4 · **Prioridade:** P1 · **Milestone:** Expansão

**Depende de:** US-02.2, US-04.2

*Como terapeuta ou cuidador, quero restringir as cores das placas e dos setores e baixar o brilho do jogo, para que a criança com aversão ou hiperfoco numa cor jogue, e eu controle a luz do ambiente sensorial como faço com o volume.*

**Requisitos do SGDD que ela realiza:**

- `RT-05` — Menu para seleção e restrição de paletas de cores (prevenção de aversão/hiperfoco por cores)
- REQ-P2-01, §10.2 Visual, LAC-17 — o seletor de paleta das Configurações permite escolher uma paleta com cores retiradas; a cor retirada vira um cinza neutro claro e não aparece em placa nem em setor
- §10.3-2 — com a paleta restrita, os setores continuam distinguíveis pelo símbolo
- §2.3, §10.1, LAC-26 — as Configurações Sensoriais têm um ajuste de brilho de 70% a 100%, que vale do menu ao jogo e entre sessões

**Cenários de aceite:**

- Dado uma paleta sem o amarelo escolhida no seletor, quando a fase monta, então nenhum setor nem placa usa amarelo, e os setores se distinguem pelo símbolo.
- Dado o brilho em 70%, quando a fase começa, então a cena aparece mais escura que a 100%; e, com o jogo reaberto, o valor continua.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-06.4.1 | `PaletaDeSetores` (ScriptableObject) com as 6 cores e os 6 símbolos da LAC-17, lida por placas e setores, e o asset dela; retirar cores pelo seletor que já existe: o `paletaCoresIndex`, escolhido no `dropdownPaleta`, passa a ser lido por placas e setores, cada opção uma paleta com as cores retiradas em cinza neutro, gravada entre sessões; teste PlayMode: a cor retirada não aparece em placa nem em setor | 2 h · presentation |
| T-06.4.2 | `BrilhoDaTela`: aplica o brilho do `SettingsManager` (70 a 100%, gravado entre sessões) à exposição do Volume do campo `volumeGlobal`, pelo slider do campo `controleBrilho`; o Volume global com Color Adjustments nas cenas Menu e Gameplay e o slider com ícone no painel; teste PlayMode: o brilho vale do menu ao jogo | 2 h · presentation |
| T-06.4.3 | O seletor de paleta nas Configurações: o `paletaCoresIndex` (SettingsManager.cs:31-33), escolhido no `dropdownPaleta` do `PainelOptionsUI` (:13, :30, :55-58) | já existe · presentation |

## 4.7 EP-07 — Arte, som e métricas finais

**Milestone:** Expansão

O robô, a fábrica, os ícones, a abertura e os sons finais, as métricas derivadas do arquivo da sessão e o marco da Expansão.

**Por que importa:** A arte e o som finais são parte do cuidado sensorial do SGDD, e as métricas provam que a telemetria basta para o estudo.

**Pronto quando:**

- O marco US-07.5 foi jogado na build de PC com a Expansão, com o mediador;
- O mesmo arquivo dá as mesmas métricas em duas rodadas.

## 4.7.1 US-07.1 — Ver o robô final e a abertura

**Perfil:** Criança · **Horas:** 8 · **Prioridade:** P2 · **Milestone:** Expansão

**Depende de:** US-02.1, US-01.2

*Como criança, quero ver um robô simpático e, na primeira vez, quem ele é e o que faz, para que eu me sinta seguro jogando e entenda a missão de entregar com cuidado.*

**Requisitos do SGDD que ela realiza:**

- §7.3, §10.2 Cultural — o robô é cartunesco, arredondado e em tons pastéis
- §4.2 A — o robô tem as animações de andar, girar, carregar a caixa e confirmar a entrega
- roteiro 30 — trocar a arte não muda nenhum teste de regra nem de telemetria
- §7.2, LAC-28 — a abertura mostra o robô sendo ligado e levando a primeira caixa ao setor, com cuidado, em até 15 s e sem texto; toca na primeira abertura do participante e de novo pelo [Tutorial]
- §10.1 — a abertura pode ser pulada e não tem flash nem som abrupto

**Cenários de aceite:**

- Dado a arte final, quando o jogo abre, então o robô é cartunesco, arredondado e em tons pastéis, e nenhum teste de regra ou de telemetria muda.
- Dado um participante novo, quando o jogo abre, então a abertura toca antes do menu; e tocar na tela vai ao menu.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-07.1.1 | O modelo do robô cartoon, arredondado e pastel | 2 h · arte |
| T-07.1.2 | As animações do robô (andar, girar, carregar e confirmar) e a troca do robô provisório pelo final, sem mudar colisor nem pivô | 2 h · arte |
| T-07.1.3 | A animação de abertura do robô, de até 15 s, sem texto | 2 h · arte |
| T-07.1.4 | `AberturaNarrativa`: toca na primeira abertura do participante e de novo pelo [Tutorial] (campo `abertura`); o objeto da abertura, com a animação; teste: a abertura é pulável e não tem componente de texto | 2 h · presentation |

## 4.7.2 US-07.2 — Ver a fábrica e os ícones finais

**Perfil:** Criança · **Horas:** 8 · **Prioridade:** P2 · **Milestone:** Expansão

**Depende de:** US-02.2, US-02.3

*Como criança, quero ver uma fábrica limpa e calma e entender os botões pelos ícones, para que as cores me guiem sem me distrair e eu use o jogo sem ler.*

**Requisitos do SGDD que ela realiza:**

- `RT-04` — Fundo de tela 3D limpo/neutro (estilo cartoon sem distratores ou partículas piscantes)
- REQ-P1-03, §10.1 — o fundo é neutro ou branco por padrão
- §7.3 — as máquinas ficam em cabines, sem muitas máquinas expostas
- §10.2 Visual — não há partícula, flash nem decoração em movimento, e placas, robô e setores têm alto contraste entre si e com o fundo
- GP-05, §7.3 — a cor fica só nas placas, nos setores e nas caixas, sem abuso de cores no cenário
- §10.2 Linguístico, §10.1, §10.3-1 — cada botão, setor, pacote, menu e configuração tem um ícone concreto, sem rótulo de texto, e os ícones do menu são grandes

**Cenários de aceite:**

- Dado a fábrica final, quando a fase monta, então o fundo é neutro, as máquinas ficam em cabines, e placas, robô e setores se distinguem com alto contraste.
- Dado todos os botões, quando a interface é vista, então cada um tem um ícone concreto.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-07.2.1 | Os tiles finais de piso e de parede | 2 h · arte |
| T-07.2.2 | As cabines das máquinas e o fundo neutro, sem decoração em movimento | 2 h · arte |
| T-07.2.3 | Setores, placas em seta, postes e doca finais, com a cor só nos alvos e a entrada do setor grande (LG-Cai-01, LG-Cai-02) | 2 h · arte |
| T-07.2.4 | Os ícones concretos dos botões (com os dois do avanço, LG-Cai-06), dos 6 símbolos de setor, da doca, da caixa e das configurações | 2 h · arte |

## 4.7.3 US-07.3 — Ouvir o jogo final, e jogar também sem som

**Perfil:** Criança · **Horas:** 6 · **Prioridade:** P2 · **Milestone:** Expansão

**Depende de:** US-04.2, US-02.3

*Como criança, quero ouvir sons suaves e poder jogar mesmo com o som desligado, para que o som da fábrica não me incomode e a falta de áudio não me atrapalhe.*

**Requisitos do SGDD que ela realiza:**

- `RT-08` — Opção de desativação total da BGM mantendo apenas SFX de ação ativos
- `RT-09` — Eliminação total de alarmes de erro, buzinas e timbres estridentes em falhas
- §4.2 A, B — acerto, obstrução, coleta e botões têm SFX curtos e suaves (até 1 s e −6 dBFS de pico)
- §7.3, GP-06, LG-Cai-22, LA-07 — o som fabril vem com volume zero por padrão, tem volume próprio nas Configurações Sensoriais, independente da música, e é baixo quando ligado
- §10.2 Auditivo — todo evento sonoro tem um equivalente visual direto, e com o áudio desligado o jogo continua jogável do menu ao fim de uma fase

**Cenários de aceite:**

- Dado os sons finais, quando se joga, então nenhum é alarme, buzina ou timbre estridente; e, com a música desligada, os efeitos continuam.
- Dado nenhuma configuração gravada, quando a fase começa, então o som fabril não toca.
- Dado o áudio desligado, quando a criança entrega ou o robô esbarra, então o brilho mostra o acerto, e a parada e a retenção da caixa mostram o impedimento.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-07.3.1 | Os SFX finais: acerto, obstrução, coleta e botões | 2 h · arte |
| T-07.3.2 | A música calma e o ambiente fabril baixo | 1 h · arte |
| T-07.3.3 | O som fabril com volume próprio, zero por padrão: o `volumeFabril` no `SettingsManager`, gravado entre sessões e independente da música, a fonte no campo `fonteFabril` e o controle no `sliderSomFabril` do `PainelOptionsUI`; ligar o AudioSource do ambiente e o controle com ícone no painel; teste EditMode do padrão zero | 2 h · presentation |
| T-07.3.4 | Conferir que todo evento sonoro tem o equivalente visual direto (brilho, pulso, parada) e completar o que faltar, com o teste PlayMode de áudio mudo | 1 h · presentation |

## 4.7.4 US-07.4 — As métricas da sessão saem do arquivo, sempre iguais

**Perfil:** Pesquisador · **Horas:** 6 · **Prioridade:** P1 · **Milestone:** Expansão

**Depende de:** US-04.4

*Como pesquisador, quero calcular a hesitação, a latência angular, a eficiência de rota, a suavidade e a aceleração a partir do arquivo da sessão, e reconstruir a partida só da telemetria, para que eu confira que a telemetria basta para o estudo e que os números são confiáveis.*

**Requisitos do SGDD que ela realiza:**

- `RT-15` — Registro contínuo e silencioso de biomarcadores (hesitação, eficiência e suavidade de rota)
- `RT-16` — Geração automática de relatório quantitativo de desempenho pós-sessão para o terapeuta *(o relatório é do servidor; aqui, as métricas que ele usa)*
- §3.2, REQ-P3-01, LG-Cai-19 — saem, por intersecção, a hesitação (os segundos abaixo de 0,05 m/s, sem comando) e a latência angular
- §3.2, §11.3 B.1, LG-Cai-19 — saem, por entrega, a eficiência de rota (a rota mínima, com o bloqueio ativo, dividida pela percorrida), a suavidade (1 dividido pelas arrancadas da entrega) e a aceleração
- roteiro 35 — a partida se reconstrói das amostras e dos eventos gravados, e o mesmo arquivo dá os mesmos números em duas rodadas
- §3.2 — a pausa não distorce as métricas

**Cenários de aceite:**

- Dado o arquivo de uma sessão, quando o cálculo roda, então cada intersecção tem a hesitação e a latência angular, e cada entrega, a eficiência, a suavidade e a aceleração.
- Dado o mesmo arquivo, quando o cálculo roda duas vezes, então os números são iguais; e uma sessão com pausa não sai distorcida.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-07.4.1 | Calculadora em C# puro: a hesitação e a latência angular por intersecção; teste EditMode com uma sessão sintética de resultado conhecido | 2 h · telemetria |
| T-07.4.2 | A eficiência de rota, a suavidade e a aceleração por entrega; teste EditMode com a mesma sessão sintética, em duas rodadas iguais | 2 h · telemetria |
| T-07.4.3 | Reconstruir a partida da telemetria e recalcular as métricas; teste: duas reconstruções dão o mesmo resultado, e a sessão com pausa não sai distorcida | 2 h · telemetria |

## 4.7.5 US-07.5 — Marco Expansão: o jogo inteiro do SGDD, no PC

**Perfil:** Terapeuta · **Horas:** 2 · **Prioridade:** P1 · **Milestone:** Expansão · **história de marco Expansão**

**Depende de:** todas as outras histórias do Expansão e do marco Core (US-04.5).

*Como terapeuta, quero conduzir na build de PC uma sessão com tudo o que o SGDD pede, com a arte e o áudio finais, para que eu veja o jogo inteiro funcionando.*

**Cenários de aceite:**

- Dado a build de PC com a Expansão, quando o terapeuta conduz uma sessão pelo painel — perfil, calibração, Fase 0, pausa e interrupção com motivo —, então tudo funciona, e o arquivo da sessão traz os eventos, os parâmetros recebidos e o motivo.
- Dado a mesma sessão, quando o `Player.log` é aberto, então não há exception.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-07.5.1 | Gerar a build de PC com a Expansão, jogá-la do menu ao fim com o mediador (painel, perfil, calibração e interrupção com motivo) e conferir no arquivo da sessão os eventos, os parâmetros recebidos (`session_parameters_received`) e o motivo contra o que foi jogado | 2 h · build |

# 5 ORDEM DE TRABALHO

Os milestones não têm data: a ordem é a das dependências. Dentro de cada milestone, as histórias seguem esta sequência; a Expansão começa depois do marco Core (US-04.5).

**Core**

| # | História | Horas | Acumulado |
| --- | --- | --- | --- |
| 1 | US-01.1 — O projeto da `fase0` abre na `develop` e vira um jogo de PC | 4 h | 4 h |
| 2 | US-01.2 — Escolher a fase no menu e começar | 2 h | 6 h |
| 3 | US-02.1 — Andar e girar o robô, vendo o que está à frente | 2 h | 8 h |
| 4 | US-02.2 — Reconhecer os setores e seguir as placas da cor | 6 h | 14 h |
| 5 | US-02.3 — Levar a caixa ao setor da mesma cor | 9 h | 23 h |
| 6 | US-03.1 — Jogar as Fases 1 a 3, cada uma na sua fábrica | 4 h | 27 h |
| 7 | US-03.2 — As placas se escondem no meio da fase | 8 h | 35 h |
| 8 | US-03.3 — Corredores bloqueados, e as Fases 4 e 5 | 8 h | 43 h |
| 9 | US-04.1 — A fase termina, e a seguinte começa | 6 h | 49 h |
| 10 | US-02.4 — Uma seta mostra aonde ir | 2 h | 51 h |
| 11 | US-04.2 — Pausar, ajustar o som e sair | 6 h | 57 h |
| 12 | US-04.3 — Cada decisão da criança vira um registro | 6 h | 63 h |
| 13 | US-04.4 — A sessão fica gravada num arquivo, com o código do participante | 6 h | 69 h |
| 14 | US-04.5 — Marco Core: do menu ao fim das Fases 1 a 5, no PC | 2 h | 71 h |

**Expansão**

| # | História | Horas | Acumulado |
| --- | --- | --- | --- |
| 1 | US-05.1 — Treinar na Fase 0, uma coisa de cada vez | 6 h | 6 h |
| 2 | US-05.2 — Ver o robô mostrar cada etapa, também em Libras | 8 h | 14 h |
| 3 | US-06.1 — O mediador calibra e interrompe a sessão pelo painel | 8 h | 22 h |
| 4 | US-06.4 — Restringir as cores e baixar o brilho | 4 h | 26 h |
| 5 | US-06.2 — O perfil da criança ajusta o jogo | 5 h | 31 h |
| 6 | US-06.3 — A partida recebe os parâmetros de fora e grava o que recebeu | 4 h | 35 h |
| 7 | US-07.1 — Ver o robô final e a abertura | 8 h | 43 h |
| 8 | US-07.2 — Ver a fábrica e os ícones finais | 8 h | 51 h |
| 9 | US-07.3 — Ouvir o jogo final, e jogar também sem som | 6 h | 57 h |
| 10 | US-07.4 — As métricas da sessão saem do arquivo, sempre iguais | 6 h | 63 h |
| 11 | US-07.5 — Marco Expansão: o jogo inteiro do SGDD, no PC | 2 h | 65 h |

# 6 RASTREIO DOS REQUISITOS

Os `RT-xx` são as 19 linhas da §12 do SGDD, na ordem dela. Cada uma cai em pelo menos uma história; as histórias trazem também os requisitos das outras seções do SGDD, com a seção ao lado.

| RT | Requisito (§12 do SGDD) | Histórias |
| --- | --- | --- |
| RT-01 | Navegação 3D egocêntrica com orientação por placas de cores em intersecções | US-02.1, US-02.2 |
| RT-02 | Mecânica de entrega de pacotes nos setores fabris correspondentes à cor | US-02.3 |
| RT-03 | Perturbação ambiental dinâmica (ocultação de placas por fumaça e bloqueio de corredores) | US-03.2, US-03.3 |
| RT-04 | Fundo de tela 3D limpo/neutro (estilo cartoon sem distratores ou partículas piscantes) | US-03.2, US-07.2 |
| RT-05 | Menu para seleção e restrição de paletas de cores (prevenção de aversão/hiperfoco por cores) | US-06.2, US-06.4 |
| RT-06 | Feedback de acerto suave e focado (brilho direcionado no setor sem flashes piscantes) | US-02.3 |
| RT-07 | Controle de volume independente para música de fundo (BGM) e efeitos sonoros (SFX) | US-04.2 |
| RT-08 | Opção de desativação total da BGM mantendo apenas SFX de ação ativos | US-04.2, US-07.3 |
| RT-09 | Eliminação total de alarmes de erro, buzinas e timbres estridentes em falhas | US-02.3, US-03.3, US-07.3 |
| RT-10 | Onboarding prático na Fase 0 exclusivamente por animação e demonstração visual (sem texto) | US-05.1, US-05.2 |
| RT-11 | Interface minimalista (HUD) com enquadramento exclusivamente positivo de pontos acumulados | US-02.3 |
| RT-12 | Suporte duplo a controles: Teclado (PC) e botões virtuais touchscreen amplos (Tablets) *(v1.3, 26/11/2026: o dispositivo-alvo é o PC; ver §2.2.)* | US-02.1 |
| RT-13 | Recepção de parâmetros de fase (velocidade, fumaça, bloqueios) via servidor `research.ciatec.org` | US-03.1, US-06.1, US-06.3 |
| RT-14 | Regressão silenciosa de dificuldade (redução de perturbação) sem telas de "Game Over" | US-06.3 |
| RT-15 | Registro contínuo e silencioso de biomarcadores (hesitação, eficiência e suavidade de rota) | US-04.3, US-04.4, US-07.4 |
| RT-16 | Geração automática de relatório quantitativo de desempenho pós-sessão para o terapeuta | US-07.4 |
| RT-17 | Tempo máximo de cada fase entre 20 a 30 minutos (programável) | US-04.1 |
| RT-18 | Atalho de pausa e botão de interrupção de emergência de sessão pelo terapeuta | US-04.2, US-06.1 |
| RT-19 | Definição e aplicação de critérios explícitos para interrupção de protocolo longitudinal | US-04.1, US-06.1 |

# 7 DECISÕES QUE VALEM

As decisões vêm do ABD v0.11, com os IDs trocados pelos desta versão ("antiga US-xx" ou "antiga TASK-nnn" é uma história ou task que já tinha saído do backlog antes desta reescrita).

## 7.1 Lacunas do SGDD e decisões provisórias

LAC-01 a LAC-06 são as linhas da §13 do SGDD, na ordem dela; LAC-07 em diante foram achadas na leitura do ABD. **Nenhuma bloqueia história.** As marcadas **Decidida pelo orientador em 26/11/2026 (LG-Cai-xx)** valem como regra (e estão no SGDD, no ponto que alteram); as outras têm uma **decisão provisória — confirmar com o pesquisador**: a história começa com ela, e, se o pesquisador a mudar, a história muda junto (quando confirmar, na seção 7.3).

| ID | Lacuna | Fonte | Decisão provisória — confirmar com o pesquisador | Razão | Histórias |
| --- | --- | --- | --- | --- | --- |
| LAC-01 | Amostra de só 1 participante de Suporte 2 no PPI | §13 | Os parâmetros do Suporte 2 do §11.3 B.2 valem como estão; o ciclo complementar fica fora do jogo (v0.9) | O SGDD já os dá; o ciclo é o que os confirma | US-06.2 |
| LAC-02 | Posição no Triple Diamond não confirmada | §1, §13 | Tratar o projeto como no 2º Diamante (backlog e desenvolvimento) | O backlog existe e o orientador mandou executá-lo | nenhuma: fora do jogo (antiga US-10.6 cortada) |
| LAC-03 | Unity ou Flutter no móvel | §7.4, §13 | **Decidida pelo orientador em 26/11/2026 ("pra simplificar"):** o dispositivo-alvo é o PC (Windows, mouse e teclado), em Unity; não há build móvel nem vibração, e nada novo se cria para toque | Um jogo funcionando antes; os botões de toque que o código já tem ficam | US-01.1; US-02.1 (só o que já existe) |
| LAC-04 | Limiares de hesitação que disparam a regressão silenciosa | §13, §4.3 | **Especificação do backend (v0.9):** a regra roda no backend (decisão do orientador, 26/11/2026, padrão CIATEC), e estes valores vão a ele como proposta, a confirmar ao abrir a conexão com a API. Os do jogo que o orientador jogou e validou em 26/11/2026: dispara com mais de 8 s parado numa intersecção sem comando, 2 tentativas no setor errado na mesma entrega, ou a entrega passando de 2 vezes o tempo-alvo do perfil (no Suporte 3, sem tempo-alvo, esse sinal não existe); **no máximo 1 ajuste por entrega**; o ajuste tira 25 pontos da opacidade de todas as placas cobertas e, **só se nenhuma placa estiver coberta**, libera 1 via bloqueada. Os três limiares (8 s, 2 erros, 2 vezes) ficam na configuração | São os valores que o orientador validou jogando; o piloto do §13 os recalibra, no backend | nenhuma neste backlog; ajuste do servidor (API, US-08.6) |
| LAC-05 | Telemetria offline-first | §13 | Não é decisão: gravação em arquivo local neste backlog; a sincronização está em `ABD-1-Caique-api.md` | É ação pedida pelo próprio §13; a ordem segue a decisão do orientador de 25/11/2026 | US-04.4; sincronização (API) |
| LAC-06 | Sem validação em uso domiciliar | §13 | Não é decisão: o protocolo domiciliar ficou fora do jogo (v0.9) | É ação pedida pelo próprio §13, e não é jogo nem telemetria | nenhuma (antiga US-10.8 cortada) |
| LAC-07 | Condição de fim de fase não definida | §7.1, §11.1; sugestões §3 | A fase termina ao completar as entregas do dado (5 a 30; 2 na Fase 0, de treino); o teto de tempo encerra por segurança, nunca por fracasso | É o que §5.1, §7.1 e §11.1 implicam (sugestões §3.1) e não cria condição de derrota | US-04.1 |
| LAC-08 | Durações contraditórias (§5.1, §7.1, §8, §9.2, §11.1–11.3, §12) | §5.1, §7.1, §8, §9.2, §11.1–11.3, §12 | **Decidida pelo orientador em 26/11/2026 (LG-Cai-05, LG-Cai-07, LG-Cai-17):** **Tentativa** = uma entrega, com o **tempo-alvo do perfil: 45 s no Suporte 1, 30 s no Suporte 2 e nenhum no Suporte 3** (o "tempo por fase" do §11.3 A, decidido pelo orientador em 26/11/2026); passar dele só marca a telemetria e alimenta o ajuste, e sem tempo-alvo toda entrega conta como no tempo. **Sessão** = uma partida de uma fase, com **um teto só**, contado **por sessão** (não por dia): é o "tempo máximo de cada fase" do RT-17, a "interrupção do protocolo" do §11.2 e a "duração máxima" do §7.1; valor da configuração, de 20 a 30 min, padrão 20; ao batê-lo, um evento (`session_time_cap_reached`) e um motivo (`teto_de_tempo`). A duração de 10 a 20 min do §5.1 é referência, não parâmetro: 5 a 30 entregas a 30–60 s dão de 2,5 a 30 min, e a fase termina pelas entregas (LAC-07). Pela LG-Cai-05, passados 30 s sem entregar, em qualquer perfil, a seta-guia volta (US-02.4, LA-03); pela LG-Cai-17, a entrega em curso termina antes de a sessão fechar (LA-04); pela LG-Cai-07, sessão = partida | Cada número do SGDD cabe num nível sem criar dois relógios; nenhum vira cronômetro visível (REQ-P2-03) | US-04.1, US-06.2, US-06.1, US-02.4 |
| LAC-09 | A e D giram o robô ou a câmera? Papel do mouse | §2.2, §4.1, §7.1 | **Decidida pelo orientador em 26/11/2026 (LG-Cai-14; o giro é contínuo, conforme a implementação do aluno, v0.8):** A e D giram o robô, e a câmera gira junto, presa a ele; o mouse serve só aos menus. A sensibilidade fica, conforme a implementação do aluno (v0.8): o painel de opções escolhe o esquema de controle (teclado, mouse ou toque) e a sensibilidade de cada um, de 0,2× a 3× (padrão 1×), que multiplica o giro de 110°/s | O §4.1 é a seção da mecânica; com a câmera presa, o §7.1 também se cumpre; o §10.2 Motor não dá papel ao mouse | US-01.2, US-02.1 |
| LAC-10 | Câmera egocêntrica ou 3ª pessoa | §4.1, §10.3 | **Decidida pelo orientador em 26/11/2026 (LG-Cai-14):** 3ª pessoa baixa, logo atrás e acima do robô, com campo de visão de 60° na vertical (cerca de 91° na horizontal em 16:9), conforme a implementação do aluno (v0.8) | O §4.2 A põe brilho e animação no robô, que precisa aparecer; o §10.3-2 admite a 3ª pessoa | US-02.1 |
| LAC-11 | Quantos pacotes o robô carrega | §5.1, §10.3 | **Decidida pelo orientador em 26/11/2026 (LG-Cai-11):** Uma caixa por vez na v1: o robô coleta uma caixa na doca, na ordem do dado, entrega e volta à doca para a seguinte, até o total de entregas da fase; o HUD mostra a caixa que ele leva. **Na v0.9 o código do aluno fica como está:** o robô vazio pega o pacote encostando, e o pacote seguinte reaparece alternando azul e verde (CicloEntregaManager.cs:66-73); a ordem do dado não se implementa | Um alvo por vez é mais fácil de entender (LG-Cai-02) e mantém a medida de hesitação limpa | US-02.3 |
| LAC-12 | Conteúdo das fases, mapa fixo ou gerado, variantes da Fase 0 | §5.2, §11.1, §11.3 | **Decidida pelo orientador em 26/11/2026 (LG-Cai-10, LG-Cai-12, LG-Cai-15):** Mapa fixo por fase, montado à mão (conforme a implementação do aluno, v0.8) e, desde a v1.1, escrito num arquivo de texto que o jogo transforma na fábrica (ideia do aluno; orientador, 26/11/2026), semente só nas perturbações. Fase 0: 6 intersecções, 2 setores, 2 entregas (exceção de treino das faixas; conforme a implementação do aluno, v0.8), uma etapa para o movimento, a entrega e cada um dos sete obstáculos. Fase 1: 6 intersecções, 3 setores, 5 entregas. Fase 2: 10, 3 setores, 5 entregas, fumaça a 50% (as entregas das Fases 1 e 2 e os setores e a fumaça da Fase 2, conforme a implementação do aluno, v0.8). Fase 3: 12, 5 setores, 15 entregas, ocultação 50–100% em até 1/3 das placas. Fase 4: 14, 5 setores, 20 entregas, 1 a 2 bloqueios. Fase 5: 18, 6 setores, 20 entregas, ocultação e até 3 bloqueios. A Fase 1 não tem perturbação; nas Fases 2 a 5, a perturbação entra depois da 3ª entrega; os 5 setores chegam na Fase 3. Fase 0 rápida, guiada e estendida como na US-06.2 | Sobe uma dimensão por fase (REQ-P2-04, §11.3 B.1), dentro das faixas do §11.1; mapa fixo preserva a reprodutibilidade (sugestões §2.3) | US-02.2 e US-03.1, US-03.3, US-03.2, US-05.1, US-06.2 |
| LAC-13 | Quem mostra os biomarcadores ao terapeuta | §4.2 E, §9.3, §10.3 | **Fora do jogo (v0.9, orientador, 26/11/2026):** o resumo e o relatório para o terapeuta são do backend (LAC-15), com as métricas que o jogo calcula (US-07.4); a antiga US-07.6 foi cortada. A proposta anterior: o jogo mostra o resumo no painel do mediador, fora da vista da criança, e o exporta | O §10.3 não tem tela de resultados para a criança; o terapeuta precisa ver mesmo sem servidor | nenhuma (antiga US-07.6 cortada) |
| LAC-14 | Forma de integração com a plataforma e contrato | §7.4, §12; roteiro 17, 39–43 | **Decisão do orientador (25/11/2026), não provisória:** neste backlog, telemetria e registro só em arquivo local, em formato documentado; sem cliente de API, servidor nem mock de servidor. A forma de integração e o contrato estão em `ABD-1-Caique-api.md` | O orientador mandou o arquivo local primeiro | US-04.4 |
| LAC-15 | Painel de calibração, ajuste e relatório são do servidor | §4.2 D, §9.3; `ciatec-paradigma.md` | O servidor é da equipe do `research.ciatec.org`; o jogo tem painel do mediador com os mesmos parâmetros, gravados em arquivo local, regra local de ajuste e resumo exportado em arquivo | O terapeuta calibra e vê o resumo sem servidor, como pede a decisão de 25/11/2026 | US-06.1, antiga US-07.6; validação com o servidor (API) |
| LAC-16 | CEP e LGPD não aparecem no SGDD, e o jogo coleta dados de crianças | §2.3, §3.2 | **Fora do jogo (v0.9, orientador, 26/11/2026):** ética, consentimento e dados são tratados fora do jogo (CEP e backend); o jogo grava o código do participante, sem dado pessoal (T-04.4.3, US-04.4). A proposta anterior, para quem tratar disso: coleta real só com a flag de coleta autorizada (ligada com o CEP aprovado) e o consentimento registrado; sem isso, modo teste marcado; participante por código; exportar e apagar por participante | `context-ciatec.md` proíbe dado real antes do CEP; a LGPD dá ao titular acesso e exclusão | US-04.4 (código do participante); o resto fora do jogo |
| LAC-17 | Cor e símbolo de cada setor; paleta restringível | §4.1, §9.2, §10.2, §10.3 | **Decidida pelo orientador em 26/11/2026 (LG-Cai-18):** Seis setores, cor pastel e símbolo: azul/círculo, amarelo/estrela, verde/triângulo, laranja/quadrado, roxo/losango, rosa/hexágono; sem vermelho; cor retirada vira cinza neutro e o setor segue pelo símbolo; Suporte 3 usa azul, amarelo e verde em saturação cheia. **Na v0.9 o código do aluno fica como está:** a restrição se escolhe no seletor de paleta que já existe (`dropdownPaleta`, uma paleta por opção) | O símbolo garante a distinção com paleta restrita e para quem não distingue cores; o §4.2 associa vermelho a erro | US-02.2, US-06.4 |
| LAC-18 | Com que entrada o terapeuta pausa e interrompe | §9.3 | **Decidida pelo orientador em 26/11/2026 (LG-Cai-16; a criança pausa também pelo Esc, e [Sair] volta ao menu sem passar pela conclusão):** F10 no PC e segurar o botão de pausa por 3 s; abre o painel do mediador | Fora do alcance de um clique acidental da criança | US-06.1 |
| LAC-19 | Regra de avanço; botão de avanço; seletor de fases da `fase0` | §4.3, §10.3, §11.2 | **Decidida pelo orientador em 26/11/2026 no botão e na janela (LG-Cai-06, LG-Cai-07):** o avanço olha 3 partidas seguidas (configurável), o mediador pode liberar a fase pelo painel, e o botão da conclusão leva à próxima partida, com um ícone diferente quando a fase muda. **Provisória, a confirmar:** desempenho da partida = % de entregas feitas na primeira tentativa e no tempo-alvo (v0.9: especificação da regra de avanço, que roda no backend); a primeira sessão passa pela Fase 0. **Conforme a implementação do aluno (v0.8):** o seletor de fases fica no menu da criança ([Jogar], o `ClicarStart`, abre o carrossel, e tocar o card central abre a fase); e ele fica como está, com todas as fases abertas (LA-13, decidida pelo código na v0.9) | Mede consistência e não acerto bruto (GP-03); mantém o botão sem interrupção (§10.3-4) | US-01.2, US-05.1, US-04.1, US-06.3 |
| LAC-20 | A fumaça só esconde a placa ou também barra | §2.1, §4.1, §4.2 B, §10.2, §11.1 | Só esconde a placa; a desaceleração do §4.2 B vale diante do bloqueio físico; a fumaça é uma camada estática de opacidade, sem partículas | O §11.1 separa fumaça (opacidade da placa, Fases 2, 3 e 5) de bloqueio (vias, Fases 4 e 5) | US-03.2, US-03.3 |
| LAC-21 | O modelo de eventos e telemetria não está no SGDD | sugestões §1; roteiro 9 | **Decidida pelo orientador em 26/11/2026 (LG-Cai-19; hesitação = segundos na intersecção abaixo de 0,05 m/s sem comando; eficiência = rota mínima dividida pela percorrida; suavidade = 1 dividido pelas arrancadas da entrega; 10 amostras por segundo; arquivos locais):** O modelo das sugestões §1.3 e §1.4, inteiro, com `offset_ms` | É a proposta que já existe e cobre as métricas da §3.2 | antiga US-07.1, US-04.3 |
| LAC-22 | Ajuste adaptativo sem conexão | §4.2 D, §4.3, §13 | **Decidida pelo orientador em 26/11/2026 (v0.9):** a adaptação é do backend (padrão CIATEC); o jogo não calcula ajuste nem progressão. Sem conexão, e enquanto a API não existe, um provedor local devolve os parâmetros fixos do preset da fase, sem ajuste durante a fase; o ajuste do servidor está em `ABD-1-Caique-api.md` | A regra fica num lugar só, o do padrão CIATEC, e o Core segue jogável sem rede | US-06.3 |
| LAC-23 | Instrução em Libras sem requisito | §3A, §4.4 | **Decidida pelo orientador em 26/11/2026 (LG-Cai-20; até a gravação, um intérprete desenhado provisório; **a gravação por intérprete continua pendência**):** Janela de vídeo em Libras por etapa da Fase 0, desligada por padrão, gravada por intérprete | O GP-01 a pede; ligável, não pesa para quem não usa | US-05.2 |
| LAC-24 | Duas tabelas de hipóteses na §13A, com textos diferentes | §13A | Vale a segunda tabela (H-01 a H-10) | É a mais completa e a única com H-07 a H-10 | nenhuma: fora do jogo (antiga US-10.4 e antiga US-10.5 cortadas) |
| LAC-25 | Formas de ocultar a placa e de bloquear o corredor | §2.1, §4.1, §4.2 B | **Decidida pelo orientador em 26/11/2026 (LG-Cai-12):** Fumaça, sujeira, placa quebrada e placa em manutenção são o mesmo parâmetro de ocultação com visuais diferentes; obra, reforma e multidão são o mesmo bloqueio com visuais diferentes; tudo estático | O §11.1 só parametriza fumaça e vias bloqueadas; as formas da premissa entram sem criar variável nova | US-03.2, US-03.3 |
| LAC-26 | "Iluminação" do ambiente sensorial do cuidador | §2.3 | **Decidida pelo orientador em 26/11/2026 (LG-Cai-24):** Ajuste de brilho de 70% a 100% nas Configurações Sensoriais | É o equivalente no jogo do controle de luz que o §2.3 dá ao cuidador | US-06.4 |
| LAC-27 | "Hardware doméstico de baixo custo" sem número | §7.4 | 30 quadros por segundo, carga de fase em até 5 s e até 1,5 GB de memória num PC com gráfico integrado e num tablet Android de entrada | Orçamento mensurável para o critério do §7.4 | nenhuma: a medição de desempenho saiu do backlog (antiga US-01.6 cortada na v0.9) |
| LAC-28 | Forma da narrativa | §7.2 | Animação de abertura de até 15 s, sem texto, pulável, na primeira abertura e revisível pelo [Tutorial] | O §7.2 dá a história e proíbe texto | US-07.1 |
| LAC-29 | O §7.4 exige Internet; o §13 pede offline-first | §7.4, §13 | Neste backlog, o jogo roda inteiro sem rede; o uso da Internet está em `ABD-1-Caique-api.md` | Concilia as duas seções e a decisão do orientador de 25/11/2026 | nenhuma neste backlog |
| LAC-30 | Regressão do §11.2 sem referência nem número para o tempo | §11.2 | **Especificação do backend (v0.9):** a regressão roda no backend; estas escolhas vão a ele, a confirmar ao abrir a conexão com a API. Queda de desempenho "acima de 15%" = desempenho da partida abaixo de 85% da média das 3 partidas anteriores na mesma fase, a mesma janela do avanço (LA-06); aumento do tempo de resposta = tempo médio por entrega acima de 115% da mesma média; "sinais de frustração" ficam com o terapeuta, que regride pelo painel do mediador | Usa a janela de 3 partidas do avanço (LG-Cai-07), e o mesmo 15% para os dois sinais medidos; frustração não se mede pela telemetria com segurança | US-06.1 (o mediador volta a fase); a regressão, no backend (API) |
| LAC-31 | A vibração do §4.2 não diz se é desligável | §4.2 A e B, §10.1 | **Decidida pelo orientador em 26/11/2026 (LG-Cai-21):** Vibração ligada por padrão no tablet, com uma chave nas Configurações Sensoriais, gravada entre sessões. **Na v0.9 o dispositivo-alvo é o PC, sem vibração** | O §10.1 pede ambiente sensorial controlável; o cuidador já controla volume e brilho no mesmo lugar | nenhuma (antiga US-03.7 cortada) |

## 7.2 Decisões do orientador sem LAC correspondente

Decisões LG-Cai de 26/11/2026 que respondem a perguntas que o ABD não tinha como lacuna. Valem como regra.

| LG | Decisão | Histórias |
| --- | --- | --- |
| LG-Cai-01 | A placa é uma seta grande com a cor e o símbolo do setor, no poste, apontando o corredor; há setas também para a doca | US-02.2, US-07.2 (LA-02; SGDD §4.1) |
| LG-Cai-02 | Na Fase 0 inteira e na 1ª entrega de cada outra fase, uma seta flutuante aponta o próximo alvo (doca, depois setor); cada setor tem cor e símbolo grandes na entrada | US-02.4, US-02.2, US-07.2 |
| LG-Cai-03 | **Mudou na v0.8**, conforme a implementação do aluno: o robô anda de forma contínua na velocidade do dado da fase, em m/s (2,5 na Fase 0, 3 na Fase 1 e 3,5 na Fase 2; padrão 3 m/s), e gira de forma contínua a 110°/s, no lugar do trecho em cerca de 1 s e do giro de 0,3 s; ajustável de 0,5× a 2× | US-02.1, US-06.1, US-03.1, US-03.3 (SGDD §4.1 v1.2) |
| LG-Cai-04 | **Substituída na v0.8**: o giro é contínuo enquanto a tecla ou o botão está apertado, conforme a implementação do aluno, e não em passos de 90° | US-02.1 (LA-01; SGDD §4.1 v1.2) |
| LG-Cai-05 | O tempo da entrega só marca a telemetria; passados 30 s, a seta-guia volta | US-02.4, US-04.1 (LA-03; SGDD §4.3) |
| LG-Cai-06 | A conclusão segue para a próxima partida, com ícone diferente quando a fase muda | US-04.1, US-07.2 |
| LG-Cai-07 | O avanço olha 3 partidas (configurável), e o mediador pode liberar a fase | US-06.1, US-06.3, US-07.5; a regra de avanço, no backend (API) (LA-06; SGDD §4.3, §11.2) |
| LG-Cai-08 | O mediador escolhe o perfil; padrão Suporte 1 | US-06.2, US-06.1 |
| LG-Cai-09 | Rota alternativa garantida é regra: mapas com desvios paralelos; probabilidade de bloqueio 0,5 por trecho bloqueável, mínimo 1 | US-03.3, US-03.1 |
| LG-Cai-13 | No setor errado o robô entra, sem barreira; a caixa fica com ele, toca um baque grave de 110 Hz, vibra duas vezes e a cor da caixa pulsa no HUD (sem vibração no PC, v0.9) | US-02.3 |
| LG-Cai-17 | Se o teto da sessão chega no meio de uma entrega, ela termina antes de a sessão fechar | US-04.1 (LA-04; SGDD §11.2) |
| LG-Cai-22 | Som da fábrica desligado por padrão; liga por um volume próprio, que começa em zero, nas Configurações Sensoriais | US-07.3 (LA-07; SGDD §7.3) |
| LG-Cai-23 | O contador de entregas é uma caixinha por entrega, em fileiras de 10, sem número | US-02.3, US-04.1 |

## 7.3 Decisões provisórias: quando confirmar

Cada decisão provisória da seção 7.1 se confirma com o pesquisador **antes de começar a primeira história que a usa**. **Sem resposta quando a história começar, ela começa com a decisão provisória**; se o pesquisador mudar a decisão depois, a história se ajusta, e a mudança entra no CHANGELOG do repositório.

| Confirmar antes de | Lacuna → primeira história que a usa |
| --- | --- |
| começar o Core | LAC-07 fim de fase → US-04.1; LAC-19 desempenho da partida e Fase 0 na primeira sessão → US-01.2 (a Fase 0 na primeira sessão é da Expansão, US-05.1, desde a v0.11); LAC-20 fumaça só esconde → US-03.2 |
| começar a Expansão | LAC-01 Suporte 2 → US-06.2; LAC-15 painel do mediador → US-06.1; LAC-28 abertura narrativa → US-07.1 |
| abrir a conexão com a API | LAC-29 Internet; LAC-04 limiares do ajuste e LAC-30 regressão, que são especificação do backend (v0.9) → nenhuma história deste backlog; as lacunas da conexão estão em `ABD-1-Caique-api.md` |
| quem tratar delas fora do jogo | LAC-02 Triple Diamond, LAC-13 resumo para o terapeuta, LAC-16 CEP e LGPD, LAC-24 tabela de hipóteses, LAC-27 orçamento de desempenho → nenhuma história deste backlog (v0.9) |

## 7.4 Lacunas do ABD

LA-01 a LA-10 surgiram ao dividir as tasks e ao aplicar as decisões LG-Cai; o orientador as decidiu em 26/11/2026. LA-11 a LA-13 vieram da leitura do código da `fase0` e ficaram decididas pelo código ("tudo que o código deles faz é pra manter", orientador, 26/11/2026).

- **LA-01 — Duração do giro (substituída na v0.8).** Era um parâmetro do dado da fase, com padrão de 0,3 s. O giro é
  contínuo, a 110°/s (`velocidadeGiroBase`, RoboController.cs:8), conforme a implementação do aluno (SGDD §4.1 v1.2).
- **LA-02 — Setas por poste (fechada).** Cada poste tem até 4 placas, **uma voltada para cada direção de chegada**,
  e o jogador vê só a que está de frente; cada placa leva **uma seta por destino** (setores ativos e doca, até 7 na
  Fase 5, em duas fileiras). O limite de 4 do §11.1 é de placas por poste, não de setas por placa (SGDD §4.1; US-02.2,
  US-03.1).
- **LA-03 — Quando a seta-guia volta (fechada).** Passados 30 s sem entregar, em todos os perfis, qualquer que seja o
  tempo-alvo do perfil (SGDD §4.3).
- **LA-04 — Entrega que não termina antes do teto (fechada).** O mediador encerra pelo atalho, US-06.1 (SGDD §11.2).
- **LA-05 — Fase 0 guiada no tablet (fechada).** Na v0.9 o dispositivo-alvo é o PC: o mediador avança a etapa com
  `F9` (US-06.2), e o toque longo no tablet saiu (antiga TASK-264 e antiga TASK-265 cortadas).
- **LA-06 — Janela da regressão (fechada).** A regressão olha as mesmas 3 partidas do avanço (SGDD §11.2). Na v0.9, a
  regressão é regra do backend (a antiga US-08.8 foi cortada), e a janela fica como especificação dele.
- **LA-07 — Onde se liga o som fabril (fechada).** Nas Configurações Sensoriais, por um **controle de volume
  próprio que começa em zero** (SGDD §7.3; US-07.3, T-07.3.3).
- **LA-08 — Estimativas (reescrita na v1.0).** Na reescrita no molde do Caça às Cores (v1.0), toda task a fazer tem de 1 a 2 h, e a história soma as das suas tasks. **As horas são previsão: o Caique as corrige ao puxar a task**, e o total se refaz com o que ele mediu. Não há conta de capacidade nem story points.
- **LA-09 — [Sair] no menu (fechada; mudou na v0.8).** O menu tem **[Sair]** em todas as plataformas, conforme a implementação do aluno
  (`ClicarExit`, MainMenuController.cs:42-48; SGDD §10.3-1 v1.2). [Configurações] traz os volumes (US-01.2).
- **LA-10 — Paleta do Suporte 2 (resolvida).** O preset do Suporte 2 (US-06.2) usa a paleta restrita (US-06.4). As duas estão na Expansão, e a US-06.2 depende da US-06.4.
- **LA-11 — Ponto de recuperação (decidida pelo código, v0.9).** O RoboController tem `RegistrarPontoRecuperacao` e
  `RecuperarPosicao` (RoboController.cs:72-85), que reposicionam o robô "caso trave ou o jogador peça ajuda", e há o
  prefab `Marker_RecoveryPoint`; nada os chama, e o SGDD não fala em reposicionar o robô. Na v0.9 o código fica como
  está (decisão do orientador, 26/11/2026): os métodos e o prefab ficam, e nenhuma task os liga.
- **LA-12 — Parâmetros do mapa com o mapa à mão (decidida pelo código, v0.9).** Com o mapa montado à mão (conforme a implementação do aluno; desde a v1.1, no arquivo de texto da fase),
  intersecções, placas e setores vêm do mapa, e o `quantidadeSetores` do `FaseDataSO` (FaseDataS0.cs:15) ninguém lê.
  O §5.3 e o REQ-P3-02 pedem que o mediador ajuste intersecções, placas e setores (US-06.1). Na v0.9 fica
  decidida pelo código (orientador, 26/11/2026): intersecções, placas e setores vêm do mapa de cada fase, o
  painel do mediador não os ajusta, e o `quantidadeSetores` fica como está. A US-06.1 ajusta os outros parâmetros.
- **LA-13 — Seletor de fases e progressão (decidida pelo código, v0.9).** O seletor de fases fica no menu da criança, conforme a implementação do aluno
  ([Jogar], o `ClicarStart`, abre o carrossel do `LevelSliderController`, e tocar o card central abre a fase), e hoje
  qualquer fase se abre por ele. A progressão do §11.2 (regra do backend; a fase chega pela US-06.3) e a liberação pelo mediador (LG-Cai-07) pedem uma
  ordem. Na v0.9 fica
  decidida pelo código (orientador, 26/11/2026): o carrossel fica como está, com todas as fases abertas, e a progressão
  vale para o botão de avanço da conclusão (US-04.1) e para a primeira sessão pela Fase 0 (US-05.1). No Core (v0.11), sem a
  US-06.3, a primeira fase se escolhe no carrossel, e o botão de avanço da conclusão abre a fase seguinte (a Fase 5 se
  repete); a primeira sessão pela Fase 0 é da Expansão.

# 8 ARTEFATOS DE IMPORTAÇÃO

- `ABD-1-Caique-issues.csv`, ao lado: os épicos, as histórias e as tasks, com o milestone, as horas (`estimate_h`), o `parent` e o `blocked_by`. As histórias que já têm issue no GitHub levam o número em `existing_issue`: US-01.2 (#2), US-03.1 (#3) e US-02.2 (#4). As tasks fechadas levam "(já existe)" no título, o label `ja-existe` e `estimate_h` vazio; `story_points` fica vazio, porque o plano conta em horas.
- `ABD-1-Caique-labels.csv`, ao lado: os labels, com o `ja-existe`. As camadas do plano viram os labels de camada que já existem: gameplay → `layer:gameplay`, presentation → `layer:presentation`, dados e conteúdo → `layer:content`, arte → `layer:assets`, telemetria → `layer:research`, build → `layer:platform`.
- `ABD-1-Caique-api.md`, ao lado: as histórias da conexão com a API (as US-08.1 a US-08.7 e as TASK-136 a TASK-157 e TASK-249 de lá), que não estão neste backlog.

**Histórico.** v0.3 a v0.11 (25 e 26/11/2026): backlog em dois milestones, dono [agente] ou [aluno] em cada task, decisões LG-Cai do orientador, alinhamento ao código da `fase0`, adaptação no backend, alvo só PC, corte de protótipo e a correção do orientador ao corte (a mecânica no Core, o tutorial na Expansão); o texto de cada versão está no backup do ABD v0.11, citado na seção 1.6. v1.0 (26/11/2026): reescrito no molde do Caça às Cores (26/11/2026) — de 53 histórias e 163 tasks para 25 histórias e 70 tasks a fazer, mais 19 já feitas; uma história por coisa que o jogador ou o mediador faz, tasks de 1 a 2 h com a camada, sem par [agente]/[aluno] nem task só de teste, cada épico num milestone só, e o que o código já faz como task fechada.
