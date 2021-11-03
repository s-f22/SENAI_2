let times = [{
    nome: "Liverpool",
    vitorias: 23,
    empates: 7,
    derrotas:1,
    golsproprio:70,
    golscontra:52
}, {
    nome: "City",
    vitorias: 24,
    empates: 2,
    derrotas:4,
    golsproprio:79,
    golscontra:21
}, {
    nome: "Tottenhan",
    vitorias: 20,
    empates: 1,
    derrotas:9,
    golsproprio:57,
    golscontra:32
}, {
    nome: "Arsenal",
    vitorias: 18,
    empates: 6,
    derrotas:6,
    golsproprio:63,
    golscontra:39
}, {
    nome: "Manchester United",
    vitorias: 17,
    empates: 7,
    derrotas:6,
    golsproprio:58,
    golscontra:40
}, {
    nome: "Chelsea",
    vitorias: 17,
    empates: 6,
    derrotas:7,
    golsproprio:50,
    golscontra:33
}, {
    nome: "Wolves",
    vitorias: 12,
    empates: 8,
    derrotas: 10,
    golsproprio: 38,
    golscontra: 36
}];

// 1.	Lista somente os times cujas vitórias sejam maior ou igual que 20
console.log('\n1.	Lista somente os times cujas vitórias sejam maior ou igual que 20')

var vinteV = times.filter(n => n.vitorias >= 20)

console.log(vinteV)


// -----------------------------------------------------------------------------------------------------------------------------------------------------


// 2.	Traga somente os nomes dos times;
console.log('\n2.	Traga somente os nomes dos times;')

var somenteNomes = times.map(n => {return n.nome})

console.log(somenteNomes)


// -----------------------------------------------------------------------------------------------------------------------------------------------------


// 3.	Adicione mais um time chamado Wolves, vitorias 12, empates 8, derrotas 10, gols proprios 38, golscontras 36;


// -----------------------------------------------------------------------------------------------------------------------------------------------------


// 4.   Mostre o nome e a quantidade de jogos(vitorias, empates e derrotas), quantidade de vitorias, empates e derrotas de um time
console.log('\n4.   Mostre o nome e a quantidade de jogos(vitorias, empates e derrotas), quantidade de vitorias, empates e derrotas de um time')

function filtro(value){
    return value.nome
}

var time = times.filter(n => {n.nome === 'Chelsea', n.vitorias, n.derrotas, n.empates, n.nome})

console.log(time)


// -----------------------------------------------------------------------------------------------------------------------------------------------------



// 5.	Informe a quantidade de jogos do campeonato;
//