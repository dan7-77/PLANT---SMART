document.addEventListener('DOMContentLoaded', function () {
    const progressBars = document.querySelectorAll('.progress-fill');

    progressBars.forEach(bar => {
        const targetWidth = bar.style.width;
        bar.style.width = '0';

        setTimeout(() => {
            bar.style.width = targetWidth;
        }, 300);
    });



    // Menu mobile
    const mobileMenuButton = document.querySelector('header button.md\\:hidden');
    const sidebar = document.querySelector('.sidebar');

    if (mobileMenuButton && sidebar) {
        mobileMenuButton.addEventListener('click', () => {
            sidebar.classList.toggle('hidden');
        });
    }
});


// BARRA DE NAVEGAÇÃO
const sidebarItems = document.querySelectorAll('.sidebar-item');
const contentSections = document.querySelectorAll('.content-section');

sidebarItems.forEach(item => {
    item.addEventListener('click', function (e) {
        e.preventDefault();

        // Remove active class from all items
        sidebarItems.forEach(i => i.classList.remove('active'));

        // Add active class to clicked item
        this.classList.add('active');

        // Get the section to show
        const sectionId = this.getAttribute('data-section');

        // Hide all sections
        contentSections.forEach(section => {
            section.classList.remove('active');
        });

        // Show the selected section
        document.getElementById(sectionId).classList.add('active');


    });
});

// Initialize first section as active
if (sidebarItems.length > 0 && contentSections.length > 0) {
    sidebarItems[0].classList.add('active');
    contentSections[0].classList.add('active');
}