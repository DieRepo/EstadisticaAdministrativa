function mensaje(titulo, mensaje, tipo) {
    var stack_bottomright = { "dir1": "up", "dir2": "left", "push":"top"};
    var opts = {
        title: titulo,
        text: mensaje,
        width: '400px',
        //stack: stack_bottomright,
        animate: {
            animate: true,
            in_class: 'rotateIn',
            out_class: 'rotateOut'
        },
        buttons: {
            sticker: false
        }
    };
    switch (tipo) {
        case 'info':
            opts.addclass = 'info';
            opts.icon = 'fas fa-info-circle';
            break;
        case 'success':
            opts.addclass = 'success';
            opts.icon = 'far fa-thumbs-up';
            break;
        case 'update':
            opts.addclass = 'update';
            opts.icon = 'fa fa-sync-alt';
            break;
        case 'warning':
            opts.addclass = 'warning';
            opts.icon = 'fas fa-exclamation-circle';
            break;
        case 'error':
            opts.addclass = 'error';
            opts.icon = 'fa fa-exclamation-triangle';
            break;

    }
    new PNotify(opts);
};

function mensajeBases(titulo, mensaje) {
    var stack_bottomright = { "dir1": "up", "dir2": "left", "push": "top" };
    var opts = {
        title: titulo,
        text: mensaje,
        width: '400',
        addclass: 'warning',
        icon: 'fas fa-exclamation-circle',
        //stack: stack_bottomright,
        animate: {
            animate: true,
            in_class: 'rotateIn',
            out_class: 'rotateOut'
        },
        buttons: {
            sticker: true
        }

    };
    new PNotify(opts);
};