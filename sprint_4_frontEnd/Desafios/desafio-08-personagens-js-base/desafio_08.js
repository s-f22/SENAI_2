let personagens = [{
    nome: "Capitão Cometa",
    dataAparicao: 1951,
    editora: "DC"
}, {
    nome: "Lanterna Verde",
    dataAparicao: 1940,
    editora: "DC"
}, {
    nome: "Ciborgue",
    dataAparicao: 1980,
    editora: "DC"
}, {
    nome: "Homem Aranha",
    dataAparicao: 1962,
    editora: "Marvel"
}, {
    nome: "Homem de Ferro",
    dataAparicao: 1963,
    editora: "Marvel"
}, {
    nome: "Capitão América",
    dataAparicao: 1940,
    editora: "Marvel"
}, {
    nome: "Capitã Marvel",
    dataAparicao: 1977,
    editora: "Marvel"
}];


//-----------------------------------------------------------------------------------------------------------------------------


// 1.   Liste somente os personagens cuja editora seja Marvel;
console.log('1. Lista somente os personagens cuja editora seja Marvel.');

let personagensMarvel = personagens.filter((personagem) => {
    return personagem.editora === 'Marvel';
});

console.log(personagensMarvel);


//-----------------------------------------------------------------------------------------------------------------------------


// 2.	Liste somente os personagem cuja data de Aparição seja superior a 1950;
console.log('\n2.   Liste somente os personagem cuja data de Aparição seja superior a 1950')

let p_maior_1950 = personagens.filter(personagem => { return personagem.dataAparicao > 1950; })

console.log(p_maior_1950)


//-----------------------------------------------------------------------------------------------------------------------------


// 3.	Some a idade de todos os personagens;
console.log("\n3.	Some a idade de todos os personagens;")

now = new Date()

/*
RESOLUÇÃO ALTERNATIVA

var idades = personagens.map(function(item){
    return now.getFullYear() - item.dataAparicao
})
console.log(idades)
var somaIdades = idades.reduce(function(total, cada){
    return total + cada
})
console.log(somaIdades)
*/

somaIdades = personagens
    .map(idade => now.getFullYear() - idade.dataAparicao)
    .reduce((somatorio, cadaIdade) => somatorio + cadaIdade, 0)

console.log(somaIdades)


//-----------------------------------------------------------------------------------------------------------------------------


// 4.	Traga somente os nomes dos personagens;
console.log('\n4.	Traga somente os nomes dos personagens;')

var somenteNomes = personagens.map(function (item) {
    return item.nome;
})

//var somenteNomes = personagens.map(n => {return n.nome})

console.log(somenteNomes)


//-----------------------------------------------------------------------------------------------------------------------------


// 5.	Adicione mais um personagem chamado Capitã Marvel, data de Aparição 1977 e editora Marvel;


//-----------------------------------------------------------------------------------------------------------------------------


// 6. Mostre a quantidade de personagens da Marvel que possuem na lista
console.log('\n6. Mostre a quantidade de personagens da Marvel que possuem na lista')

var qtdeMarvel = personagens.filter(p => p.editora === 'Marvel').length

console.log(qtdeMarvel)


//-----------------------------------------------------------------------------------------------------------------------------


// 7. Mostre o nome e a idade dos personagens
console.log('\n7. Mostre o nome e a idade dos personagens')

var nomeIdade = personagens.map(n => {return n.nome}) + personagens.map( idade => now.getFullYear() - idade.dataAparicao )

/*
var novoPersonagem = [{nome},{idade}]

novoPersonagem[0] = personagens.map(n => {return n.nome});
novoPersonagem[1] = personagens.map( idade => now.getFullYear() - idade.dataAparicao )
*/
console.log(nomeIdade)
