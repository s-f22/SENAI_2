//function toggleMenu() {
toggleMenu = () => {
    const nav = document.getElementById('nav');
    nav.classList.toggle('active');   //toggle: adicione caso não tenha, remova caso tenha
}

const btnMobile = document.getElementById('btn_mobile');

btnMobile.addEventListener('click', toggleMenu);