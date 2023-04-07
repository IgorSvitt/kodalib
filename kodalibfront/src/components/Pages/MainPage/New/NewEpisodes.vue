<template>
  <div class="new-episodes">
    <div class="new-episodes-title">
      Новые серии
    </div>
    <div class="episode-bg">
      <div class="episodes" v-show="!isLoading">
        <div v-for="episode in information" :key="episode.id" class="one-episode">
          <a :href="'/series/'+episode.seriesId+'/season/'+episode.season+'/episode/'+episode.numberEpisode+'/voiceover/'+episode.voiceoverId">
            <img :src="episode.image" class="episode-image">
            <div class="episode-title">{{ episode.seriesTitle }} {{ episode.season }} сезон {{ episode.numberEpisode }}
              серия
              <p class="voiceover">
                Озвучка "{{episode.voiceover}}"
              </p>
            </div>
          </a>
        </div>

      </div>
      <div v-if="isLoading" class="loader-container">
        <div class="loader"></div>
      </div>
    </div>

  </div>
</template>

<script>
import {onMounted, ref} from "vue";
import axios from "axios";

export default {
  name: "NewEpisodes",

  setup() {
    const isLoading = ref(true);
    const information = ref(null)

    onMounted(async () => {
      isLoading.value = true
      await axios.get("http://5.44.46.158/api/series/last-episodes")
          .then(response => {
            console.log(response.data.data)
            information.value = response.data.data
            isLoading.value = false
          })
    })

    return {
      information,
      isLoading,
    }
  },
}
</script>

<style scoped>
a{
  text-decoration: none;
  color: #efefef;
}
.new-episodes {
  margin-top: 45px;
  color: #efefef;
  font-size: 32px;
  font-weight: 600;
}

.new-episodes-title {
  margin-bottom: 20px;
}

.episodes {
  font-size: 20px;
  font-weight: 400;
  display: flex;
  justify-content: space-between;
  flex-wrap: wrap;
  padding: 20px 20px;

}

.episode-bg {
  background: rgba(0, 0, 0, 0.2);
  min-height: 470px;
  border-radius: 13px;
}

.episode-image {
  width: 300px;
  height: 180px;
  background: #392661;
  border: none;
}

.one-episode {
  display: block;
  max-width: 300px;
  margin-bottom: 15px;
  cursor: pointer;
  transition: all .3s ease;
}


.one-episode img {
  transition: all .3s ease;
}

.one-episode:hover img {
  opacity: 0.5;
  transition: all .3s ease;
  transform: scale(1.1);
}

.one-episode:hover div {
  color: #ffddcc;
  transition: all .3s ease;
}

.loader-container {
  height: 100%;
  min-height: 470px;
  display: flex;
  justify-content: center;
  align-items: center;
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

.voiceover{
  font-size: 16px;
  font-weight: lighter;
  color: rgba(255,255,255,0.5);
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