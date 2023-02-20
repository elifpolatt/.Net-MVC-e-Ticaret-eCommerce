//mobile gorunume geldıgınde calısması ıcn bu kısmı eklıyoruz
const bar = document.getElementById('bar');
const close = document.getElementById('close');
const nav = document.getElementById('navbar');


if(bar){
    bar.addEventListener('click', () =>{
        nav.classList.add('active');

    })
}
if(close){
    close.addEventListener('click', () =>{
        nav.classList.remove('active');

    })
}

//kıyafetlerın uzerındekı sepetın ustune gelınce rengının koyu yesıle donmesı gerekıyordu o da eksık 
