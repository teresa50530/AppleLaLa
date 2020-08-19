function openModal() {
    const modal = document.getElementById('modal')
    modal.classList.add('modal--open')
}

function closeModal() {
    const modal = document.getElementById('modal')
    modal.classList.remove('modal--open')
}

function handleModalClick(e) {
    const closeClasses = [
        'modal__btn-cancel',
        'modal__btn-delete',
        'modal modal--open',
    ]
    if (closeClasses.indexOf(e.target.className) > -1) {
        closeModal()
    }
}

document.getElementById('delete').onclick = openModal
document.getElementById('modal').onclick = handleModalClick