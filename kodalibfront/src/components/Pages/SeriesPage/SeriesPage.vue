<template>
  <div class="container">
    <div v-if="!isLoading && information">
      <div class="film-information">
        <series-information :seriesInformation="information"/>
      </div>
      <div>
        <series-video-player :link="information"/>
      </div>
    </div>
    <div v-if="isLoading" class="loader-container">
      <div class="loader"></div>
    </div>
  </div>

</template>

<script>
import {useRoute} from "vue-router";
import {useStore} from "vuex";
import {onMounted, ref} from "vue";
import SeriesInformation from "@/components/Pages/SeriesPage/SeriesInformation/SeriesInformation";
import SeriesVideoPlayer from "@/components/Pages/SeriesPage/SeriesVideoPlayer/SeriesVideoPlayer";

export default {
  name: "SeriesPage",
  components: {SeriesVideoPlayer, SeriesInformation},
  setup(){
    const route = useRoute()
    const store = useStore()
    const isLoading = ref(true);
    const information = ref(null)

    onMounted(async () => {
      isLoading.value = true
      await store.dispatch("series/getSerialApi", route.params.id)
      isLoading.value = false
      information.value = store.state.series.serial

      if (information.value && information.value.title) {
        document.title = information.value.title;
      }
    })

    return {
      information,
      isLoading,
    }
  }
}
</script>

<style scoped>
.film-information {
  margin: 45px 20px 0;
}

.loader-container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: calc(100vh - 215px);
}

.loader {
  border: 5px solid #ffddcc;
  border-top: 5px solid #4e3883;
  border-radius: 50%;
  width: 50px;
  height: 50px;
  animation: spin 2s linear infinite;
  margin: auto;
}

@keyframes spin {
  0% {
    transform: rotate(0deg);
  }
  100% {
    transform: rotate(360deg);
  }
}
</style>