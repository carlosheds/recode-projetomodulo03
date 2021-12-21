let menuToggle = document.querySelector('.menu-toggle');
let menu = document.querySelector('ul');
menuToggle.addEventListener('click',e => {
    if(menu.classList == "") {
        menu.classList += ' on'
        document.body.appendChild(menuOverLay)
        
    }else  menu.classList = ''
})