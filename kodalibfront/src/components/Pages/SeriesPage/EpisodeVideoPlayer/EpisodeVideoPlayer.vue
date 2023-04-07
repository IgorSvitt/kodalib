<template>
  <div class="container episode-player">
    <div v-if="!isLoading && seriesTitle">
    <div class="title-episode">
      Смотреть «{{ seriesTitle.title }}» {{ route.params.season_id }} сезон {{ episode.numberEpisode }} серия
    </div>
    <a :href="'/series/'+route.params.id" class="info-series">
      Информация о сериале
    </a>
    <iframe :src="episode.videoLink" width="100%" height="600"
            frameborder="0" allowfullscreen allow="autoplay *; fullscreen *" class="iframe-series"></iframe>

    <carousel-episodes :episodes="season" :currentSlide="episode.numberEpisodes"/>
    </div>
    <div v-if="isLoading" class="loader-container">
      <div class="loader"></div>
    </div>
  </div>
</template>

<script>
import {onMounted, ref, watchEffect} from "vue";
import {useRoute} from "vue-router";
import {useStore} from "vuex";
import CarouselEpisodes from "@/components/Pages/SeriesPage/EpisodeVideoPlayer/CaruselEpisodes/CarouselEpisodes";

export default {
  name: "EpisodeVideoPlayer",
  components: {CarouselEpisodes},
  setup: function () {
    const route = useRoute()
    const store = useStore()
    const isLoading = ref(true);
    const seriesTitle = ref(null)
    const season = ref(null)
    const episode = ref(null)

    onMounted(async () => {
      isLoading.value = true
      await store.dispatch("series/getSerialApi", route.params.id)
      isLoading.value = false
      seriesTitle.value = store.state.series.serial
      season.value = store.state.series.serial.voiceover.find(x => x.id == route.params.voiceover_id).seasons.find(x => x.numberSeason == route.params.season_id)
      episode.value = store.state.series.serial.voiceover.find(x => x.id == route.params.voiceover_id).seasons.find(x => x.numberSeason == route.params.season_id).episodes.find(x => x.numberEpisode == route.params.episode_id)
      document.title = seriesTitle.value.title;
    })


    watchEffect(() => {
      episode.value = store.state.series.serial.voiceover.find(x => x.id == route.params.voiceover_id)?.seasons.find(x => x.numberSeason == route.params.season_id)?.episodes.find(x => x.numberEpisode == route.params.episode_id)
    })

    return {
      episode,
      route,
      seriesTitle,
      season,
      isLoading
    }
  }
}
</script>

<style scoped>
.title-episode {
  color: #ffffff;
  font-size: 40px;
  margin: 45px 0 20px 0;
}

.info-series {
  color: #ffddcc;
  font-size: 24px;
}

.info-series:hover {
  color: #fed534;
}

.iframe-series {
  margin-top: 20px;
}

.container.episode-player {
  margin-bottom: 45px;
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

@media (max-width: 1340px) {
  .title-episode {
    font-size: 30px;
  }

  .info-series {
    font-size: 20px;
  }

  .iframe-series {
    height: 400px;
  }

}

@media (max-width: 752px){
  .title-episode {
    font-size: 26px;
  }


  .iframe-series {
    height: 250px;
  }

}
</style>