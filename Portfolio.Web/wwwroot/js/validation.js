// Client-Side Validation System för Portfolio
class PortfolioValidator {
    constructor() {
        this.errors = {};
        this.init();
    }

    init() {
        // Initiera validation när DOM är redo
        if (document.readyState === 'loading') {
            document.addEventListener('DOMContentLoaded', () => {
                this.setupContactForm();
            });
        } else {
            this.setupContactForm();
        }
    }

    setupContactForm() {
        const form = document.getElementById('contactForm');
        if (!form) return;

        // Real-time validation på varje fält
        const fields = ['name', 'email', 'subject', 'message'];

        fields.forEach(fieldName => {
            const field = document.getElementById(fieldName);
            if (field) {
                // Validera när användaren lämnar fältet
                field.addEventListener('blur', () => this.validateField(fieldName));

                // Rensa error när användaren börjar skriva igen
                field.addEventListener('input', () => this.clearFieldError(fieldName));

                // Visa teckenräknare för vissa fält
                if (fieldName === 'message' || fieldName === 'subject') {
                    this.addCharacterCounter(field);
                }
            }
        });

        // Form submission
        form.addEventListener('submit', (e) => this.handleContactSubmit(e));
    }

    validateField(fieldName) {
        const field = document.getElementById(fieldName);
        if (!field) return false;

        const value = field.value.trim();
        let isValid = true;
        let errorMessage = '';

        // Reset field styling
        this.clearFieldError(fieldName);

        switch (fieldName) {
            case 'name':
                if (!value) {
                    errorMessage = 'Name is required';
                    isValid = false;
                } else if (value.length < 2) {
                    errorMessage = 'Name must be at least 2 characters';
                    isValid = false;
                } else if (value.length > 100) {
                    errorMessage = 'Name cannot be longer than 100 characters';
                    isValid = false;
                } else if (!/^[a-zA-ZåäöÅÄÖ\s\-'\.]+$/.test(value)) {
                    errorMessage = 'Name can only contain letters, spaces and hyphens';
                    isValid = false;
                }
                break;

            case 'email':
                if (!value) {
                    errorMessage = 'Email address is required';
                    isValid = false;
                } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(value)) {
                    errorMessage = 'Please enter a valid email address';
                    isValid = false;
                } else if (value.length > 320) {
                    errorMessage = 'Email address is too long';
                    isValid = false;
                }
                break;

            case 'subject':
                if (!value) {
                    errorMessage = 'Subject is required';
                    isValid = false;
                } else if (value.length < 3) {
                    errorMessage = 'Subject must be at least 3 characters';
                    isValid = false;
                } else if (value.length > 200) {
                    errorMessage = 'Subject cannot be longer than 200 characters';
                    isValid = false;
                }
                break;

            case 'message':
                if (!value) {
                    errorMessage = 'Message is required';
                    isValid = false;
                } else if (value.length < 10) {
                    errorMessage = 'Message must be at least 10 characters';
                    isValid = false;
                } else if (value.length > 1000) {
                    errorMessage = 'Message cannot be longer than 1000 characters';
                    isValid = false;
                }
                break;
        }

        if (!isValid) {
            this.showFieldError(fieldName, errorMessage);
        } else {
            this.showFieldSuccess(fieldName);
        }

        return isValid;
    }

    validateAllFields() {
        const fields = ['name', 'email', 'subject', 'message'];
        let allValid = true;

        fields.forEach(fieldName => {
            if (!this.validateField(fieldName)) {
                allValid = false;
            }
        });

        return allValid;
    }

    showFieldError(fieldName, message) {
        const field = document.getElementById(fieldName);
        const errorContainer = this.getOrCreateErrorContainer(fieldName);

        // För floating labels, lägg till klasser på input-elementet
        field.classList.add('is-invalid');
        field.classList.remove('is-valid');

        errorContainer.textContent = message;
        errorContainer.style.display = 'block';

        this.errors[fieldName] = message;
    }

    showFieldSuccess(fieldName) {
        const field = document.getElementById(fieldName);
        const errorContainer = this.getOrCreateErrorContainer(fieldName);

        // För floating labels, lägg till klasser på input-elementet
        field.classList.add('is-valid');
        field.classList.remove('is-invalid');

        errorContainer.style.display = 'none';
        delete this.errors[fieldName];
    }

    clearFieldError(fieldName) {
        const field = document.getElementById(fieldName);
        const errorContainer = this.getOrCreateErrorContainer(fieldName);

        field.classList.remove('is-invalid', 'is-valid');
        errorContainer.style.display = 'none';
        delete this.errors[fieldName];
    }

    getOrCreateErrorContainer(fieldName) {
        let errorContainer = document.getElementById(fieldName + '-error');

        if (!errorContainer) {
            errorContainer = document.createElement('div');
            errorContainer.id = fieldName + '-error';
            errorContainer.className = 'invalid-feedback';
            errorContainer.style.display = 'none';
            errorContainer.style.marginTop = '0.5rem';
            errorContainer.style.fontSize = '0.875rem';
            errorContainer.style.color = '#dc3545';

            const field = document.getElementById(fieldName);
            // För floating labels: lägg till error efter floating-label div
            const floatingLabelDiv = field.closest('.floating-label');
            if (floatingLabelDiv) {
                // Om det finns en floating-label div, lägg error efter den
                floatingLabelDiv.parentNode.insertBefore(errorContainer, floatingLabelDiv.nextSibling);
            } else {
                // Fallback för vanliga formulär
                field.parentNode.appendChild(errorContainer);
            }
        }

        return errorContainer;
    }

    addCharacterCounter(field) {
        const maxLength = field.id === 'message' ? 1000 : 200;

        const counter = document.createElement('small');
        counter.className = 'form-text text-muted character-counter';
        counter.id = field.id + '-counter';
        counter.style.marginTop = '0.25rem';
        counter.style.display = 'block';
        counter.style.textAlign = 'right';
        counter.style.fontSize = '0.75rem';

        // För floating labels: lägg till counter efter floating-label div
        const floatingLabelDiv = field.closest('.floating-label');
        if (floatingLabelDiv) {
            floatingLabelDiv.parentNode.insertBefore(counter, floatingLabelDiv.nextSibling);
        } else {
            field.parentNode.appendChild(counter);
        }

        const updateCounter = () => {
            const remaining = maxLength - field.value.length;
            counter.textContent = `${field.value.length}/${maxLength} characters`;

            if (remaining < 50) {
                counter.classList.add('text-warning');
                counter.classList.remove('text-muted');
            } else {
                counter.classList.add('text-muted');
                counter.classList.remove('text-warning');
            }
        };

        field.addEventListener('input', updateCounter);
        updateCounter(); // Initial count
    }

    async handleContactSubmit(e) {
        e.preventDefault();

        // Client-side validation först
        if (!this.validateAllFields()) {
            this.showNotification('Please correct the errors before submitting the form.', 'error');
            return;
        }

        const form = e.target;
        const submitButton = form.querySelector('button[type="submit"]');

        // Visa loading state
        this.setSubmitLoading(submitButton, true);

        try {
            const formData = {
                name: document.getElementById('name').value.trim(),
                email: document.getElementById('email').value.trim(),
                subject: document.getElementById('subject').value.trim(),
                message: document.getElementById('message').value.trim()
            };

            const response = await fetch('/api/contact/send', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(formData)
            });

            const result = await response.json();

            if (response.ok && result.success) {
                this.showNotification(result.message, 'success');
                form.reset();
                this.clearAllErrors();
                this.clearCharacterCounters();
            } else {
                // Hantera server-side validation errors
                if (result.errors) {
                    this.handleServerErrors(result.errors);
                }
                this.showNotification(result.message || 'An error occurred. Please try again.', 'error');
            }

        } catch (error) {
            console.error('Network error:', error);
            this.showNotification('Network error. Please check your internet connection and try again.', 'error');
        } finally {
            this.setSubmitLoading(submitButton, false);
        }
    }

    handleServerErrors(errors) {
        Object.keys(errors).forEach(fieldName => {
            const messages = errors[fieldName];
            if (messages && messages.length > 0) {
                this.showFieldError(fieldName, messages[0]);
            }
        });
    }

    setSubmitLoading(button, isLoading) {
        const originalText = button.dataset.originalText || button.innerHTML;

        if (!button.dataset.originalText) {
            button.dataset.originalText = originalText;
        }

        if (isLoading) {
            button.disabled = true;
            button.innerHTML = '<i class="bi bi-hourglass-split me-2"></i> Sending...';
        } else {
            button.disabled = false;
            button.innerHTML = originalText;
        }
    }

    clearAllErrors() {
        const fields = ['name', 'email', 'subject', 'message'];
        fields.forEach(fieldName => this.clearFieldError(fieldName));
        this.errors = {};
    }

    clearCharacterCounters() {
        const counters = document.querySelectorAll('.character-counter');
        counters.forEach(counter => {
            const fieldId = counter.id.replace('-counter', '');
            const field = document.getElementById(fieldId);
            if (field) {
                const maxLength = fieldId === 'message' ? 1000 : 200;
                counter.textContent = `0/${maxLength} characters`;
                counter.classList.add('text-muted');
                counter.classList.remove('text-warning');
            }
        });
    }

    showNotification(message, type = 'info') {
        // Skapa eller hitta notification container
        let container = document.getElementById('notification-container');
        if (!container) {
            container = document.createElement('div');
            container.id = 'notification-container';
            container.style.cssText = `
                position: fixed;
                top: 80px;
                right: 20px;
                z-index: 9999;
                max-width: 400px;
            `;
            document.body.appendChild(container);
        }

        // Skapa notification element
        const notification = document.createElement('div');
        notification.className = `alert alert-${type === 'error' ? 'danger' : type === 'success' ? 'success' : 'info'} alert-dismissible fade show`;
        notification.innerHTML = `
            ${message}
            <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
        `;

        container.appendChild(notification);

        // Auto-remove efter 5 sekunder
        setTimeout(() => {
            if (notification.parentNode) {
                notification.remove();
            }
        }, 5000);
    }
}

// Initiera validator
const portfolioValidator = new PortfolioValidator();