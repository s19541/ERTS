import i18n from "i18next";
import { initReactI18next } from "react-i18next";
import translationEnglish from './locales/us';
import translationPolish from './locales/pl';
import translationItalian from './locales/it';

const resources = {
    us: {
        translation: translationEnglish
    },
    pl: {
        translation: translationPolish
    },
    it: {
        translation: translationItalian
    }
};

i18n
    .use(initReactI18next) // passes i18n down to react-i18next
    .init({
        resources,
        lng: "us",

        interpolation: {
            escapeValue: false // react already safes from xss
        }
    });

export default i18n;