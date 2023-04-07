import { createApp } from 'vue'
import App from './App.vue'
import router  from "@/components/Router/router"
import components from "@/components/UI"
import store from "@/Store/store"
import YoutubeIframe from '@techassi/vue-youtube-iframe';
import rate from "vue-rate"
import 'vue-rate/dist/vue-rate.css'

const app = createApp(App)

components.forEach(component => {
    app.component(component.name, component)
})

app
    .use(router)
    .use(store)
    .use(YoutubeIframe)
    .use(rate)
    .mount('#app')


