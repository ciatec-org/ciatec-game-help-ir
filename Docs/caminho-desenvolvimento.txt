Seguindo a ordem oficial do **Roteiro de Desenvolvimento** do projeto (`Unity → Calibration → Level Design → Gameplay → Telemetry → Results → Research API`) e o fluxo de telas (`Menu → Settings → Gameplay → Results`), quem nunca desenvolveu um jogo deve construir primeiro o **"esqueleto funcional"** (usando formas geométricas simples, como cubos e planos) e deixar a arte 3D para o final, garantindo que a camada visual nunca quebre a lógica experimental.

A ordem exata de desenvolvimento a partir do seu Menu atual é:

---

### 1. Dar funcionalidade ao Menu Principal e adicionar o botão de Tutorial

Antes de criar as fases, você precisa fazer as telas conversarem entre si.

* **Ajustar os botões do Menu:** Além de **Jogar (Start)**, **Configurações (Options)** e **Sair (Exit)**, adicione um botão visível para **Tutorial**. O projeto exige que a **Fase 0 (Tutorial)** esteja sempre acessível no menu principal para usuários que precisam de demonstração visual prévia, sem obrigar quem já sabe jogar a passar por ele. Mantenha apenas ícones grandes e sem textos longos.


* **Criar cenas vazias de destino:** Crie duas cenas ainda vazias chamadas `Gameplay` e `Results` e registre todas (`Menu`, `Gameplay`, `Results`) em *File > Build Settings* no Unity.


* **Programar a navegação básica:** Crie um script simples para o botão **Exit** fechar o jogo, **Options** abrir um painel por cima do menu e **Jogar / Tutorial** carregarem a cena `Gameplay`.



### 2. Construir o Painel de Configurações e Calibração (`Settings`)

No ciclo do projeto, a **Calibração** vem logo após a estrutura básica do Unity, pois o jogo precisa saber como o jogador vai controlar o robô e quais são os limites sensoriais da sessão antes de abrir uma fase.

* **Gerenciador Persistente:** Crie um objeto com `DontDestroyOnLoad` para guardar as configurações escolhidas no Menu e levá-las até a cena `Gameplay`.


* **Controles Sensoriais e de Input:** Dentro do painel que abre ao clicar em **Options**, implemente:
* **Áudio independente:** Dois *Sliders* vinculados a um `AudioMixer` para controlar separadamente o volume da música de fundo (`BGM`) e dos efeitos sonoros (`SFX`), além de um botão para mutar só a música sem desligar os sons de feedback.


* **Paleta de cores:** Opção para restringir cores dos alvos, evitando sobrecarga ou aversão sensorial.


* **Controles e sensibilidade:** Seleção entre teclado, mouse ou toque na tela (*touchscreen*), com ajuste de sensibilidade.





### 3. Criar o Sistema de Dados Parametrizados das Fases (`Level Design` — Dados)

Em vez de criar dezenas de cenas diferentes no Unity, a arquitetura do **HelpIR** usa uma **única cena de Gameplay** que lê os parâmetros de cada fase.

* **Arquivo de Dados (`ScriptableObject`):** Crie um script `FaseDataSO` para armazenar as regras de cada nível: número da fase (começando em `0` para o Tutorial), velocidade do robô, quantidade de setores, presença de fumaça nas placas e presença de bloqueios nos corredores.


* **Seletor de Fases (Opcional neste momento):** Você pode criar um carrossel (*Slider*) simples ligado ao botão **Jogar** para escolher entre a Fase 0 e as fases seguintes, facilitando o retorno a fases anteriores sem punição.



### 4. Montar o Mapa em Grid e o Protótipo Jogável (`Gameplay` — "Caixa Cinza")

Agora você construirá a mecânica central dentro da cena `Gameplay` usando apenas formas primitivas do Unity (cubos para paredes, planos para o chão e uma cápsula/cubo para o robô).

* **Mapa em Grid (Matriz XY):** Monte o labirinto da fábrica usando blocos de chão (`floor`) e parede (`wall`), marcando onde ficam os cruzamentos (`intersection_flag`), os locais das placas (`sign_slot`), os pontos de coleta de pacote (`collectible`), as entradas dos setores (`sector_entrance`) e pontos de recuperação (`recovery_point`).


* **Movimento do Robô:** Posicione a câmera na perspectiva da frente do robô (egocêntrica / 3ª pessoa) e programe o movimento por teclado/mouse e por setas direcionais grandes na tela (para tablets).


* **Ciclo de Entrega:** Programe a regra básica: o robô encosta no pacote colorido para coletá-lo, segue as placas da mesma cor e entra no setor correspondente para concluir a entrega, repetindo até atingir o total de entregas da fase. O jogo não possui vidas, derrota ou tela de *Game Over*.



### 5. Adicionar as Perturbações Progressivas e o Tutorial Visual (Fase 0)

Com o robô andando e entregando pacotes, adicione os desafios cognitivos do jogo:

* **Fumaça e Bloqueios:** Programe a ocultação visual das placas (fumaça) e o fechamento dinâmico de alguns corredores marcados como bloqueáveis (`blockable`), garantindo que os corredores principais nunca sejam bloqueados para que sempre exista uma rota livre até o destino.


* **Fase 0 (Tutorial):** Configure um mapa simples, sem tempo e sem obstáculos, exibindo apenas demonstrações visuais curtas em loop (sem textos explicativos) de como mover o robô e entregar um pacote.



### 6. Criar a Interface de Jogo (`HUD`), Menu de Pausa e Conclusão de Fase

Com a jogabilidade funcionando, adicione as telas de apoio dentro da cena `Gameplay` seguindo as regras de acessibilidade:

* **HUD Minimalista:** Mostre no canto superior o ícone/cor do pacote atual, no canto oposto o contador positivo de entregas feitas e um botão discreto de Pausa.


* **Menu de Pausa:** Uma tela limpa que congela o tempo do jogo com 4 botões icônicos: **[Continuar]**, **[Reiniciar Fase]**, **[Configurações Sensoriais]** (reaproveitando o painel do Passo 2) e **[Sair]**.


* **Tela de Conclusão:** Ao terminar as entregas, exiba uma mensagem curta e positiva destacando os acertos acumulados (nunca use luzes vermelhas piscantes ou alarmes de erro) e um botão para avançar.



### 7. Implementar a Coleta de Telemetria (`Event` e `Usage Telemetry`)

No roteiro científico, o jogo funciona como um registrador: ele não julga se o jogador foi bem ou mal, apenas grava o que aconteceu para o servidor analisar depois.

* **Eventos Discretos:** Registre com carimbo de tempo (*timestamp*) cada marco da partida: início/fim da fase, coleta de pacote, chegada em cruzamento, direção escolhida, encontro com bloqueio/fumaça, entrega concluída e retorno de caminho (*backtrack*).


* **Telemetria Contínua e Armazenamento Local:** Grave periodicamente a posição `(x, y, z)`, rotação e velocidade do robô, salvando tudo primeiro em um arquivo local no dispositivo (*offline-first*) para não perder dados se a internet oscilar.



### 8. Criar a Tela de Resultados (`Results`) e Testar 100% Offline

Antes de conectar o jogo à internet, feche o ciclo completo localmente:

* **Cálculo de Indicadores e Tela `Results`:** Calcule a partir da telemetria o tempo de hesitação nos cruzamentos (latência angular), a eficiência da rota e a suavidade do trajeto, exibindo esse resumo na cena `Results` para terapeutas e cuidadores.


* **Simulação Offline (*Mock*):** Teste o fluxo inteiro (`Menu → Settings → Gameplay → Results`) usando dados fictícios locais para validar se tudo funciona sem servidor.



### 9. Integrar a Arte 3D, Identidade Visual e Áudio Final

Somente agora substitua os cubos e planos protótipos pelos modelos 3D da fábrica, animações do robô, fundos neutros e efeitos sonoros suaves (adaptados de repositórios como o Freepik), conectando todos os sons ao `AudioMixer` criado no Passo 2 sem alterar as regras nem a telemetria já testadas.

### 10. Realizar Playtests e Conectar à `Research API`

Por fim, faça testes de usabilidade e de integridade dos dados gravados para calibrar a dificuldade das fases. Quando tudo estiver estável, substitua os dados fictícios locais pela integração oficial com o servidor `research.ciatec.org` (autenticação institucional, recebimento das configurações de sessão e envio automático da telemetria).

Quer começar agora pelo **Passo 1**, criando o script para fazer os botões do seu Menu Principal funcionarem e prepararem a transição para a cena de jogo?