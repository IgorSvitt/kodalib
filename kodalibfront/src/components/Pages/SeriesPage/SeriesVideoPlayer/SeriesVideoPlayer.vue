<template>
  <div class="bg">
    <div class="container page-video">
      <div class="episodes">
        <div class="text-video-player">
          Смотреть «{{voiceovers.title}}»
        </div>
        <div v-for="(voice, index) in voiceovers.voiceover" :key="index" class="voiceover"
             :class="{active:(index===activeVoice)}" @click="setActiveIndex(index)">
          {{ voice.voiceover }}
        </div>
        <div v-for="(season) in voiceovers.voiceover[activeVoice].seasons" :key="season.id">
          <series-seasons :season="season" :seriesId="voiceovers.id" :voiceoverId="voiceovers.voiceover[activeVoice].id"/>
        </div>
      </div>
    </div>
  </div>
</template>

<script>



import SeriesSeasons from "@/components/Pages/SeriesPage/SeriesVideoPlayer/SeriesSeasons/SeriesSeasons";
import {computed, ref} from "vue";
export default {
  name: "SeriesVideoPlayer",
  components: {SeriesSeasons},
  props:{
    link:{
      type: Object
    }
  },
  setup(props) {
    const voiceovers = computed(() => props.link)
    const activeVoice = ref(0)

    function setActiveIndex(index) {
      activeVoice.value = index
    }

    function sort_by_key(array, key)
    {
      return array.sort(function(a, b)
      {
        var x = a[key]; var y = b[key];
        return ((x > y) ? -1 : ((x < y) ? 1 : 0));
      });
    }

    const sortedVoiceover = sort_by_key(props.link.voiceover, "countEpisodes")

    return {
      voiceovers,
      activeVoice,
      setActiveIndex,
      sortedVoiceover
    }
  }

}
</script>

<style scoped>

.container.page-video{
  padding: 45px  0;
  display: flex;
}


.episodes{
  padding-left: 20px;
  width: 100%;
}

.text-video-player{
  color: #efefef;
  font-size: 40px;
  font-weight: 700;
  margin-bottom: 20px ;
  text-align: left;
  line-height: 50px;
}

.voiceover {
  color: #efefef;
  display: inline-block;
  font-size: 24px;
  margin-right: 20px;
  margin-bottom: 20px;
  border: 2px solid #4e3883;
  border-radius: 20px;
  padding: 3px 30px;
  cursor: pointer;
  transition: all .4s ease;
}

.voiceover:hover {
  background: #4e3883;
  transition: all .3s ease;
}

.voiceover.active {
  background: #4e3883;
  color: #ffddcc;
}

@media (max-width: 1340px){
  .video-player {
    padding-left: 20px;
    width: 930px;
  }

  iframe{
    height: 500px;
  }
  .text-video-player {
    color: #efefef;
    font-size: 30px;
    font-weight: 700;
    margin-bottom: 20px;
    text-align: left;
    line-height: 50px;
  }

  .text-video-player span {
    font-weight: 400;
  }


  .container.page-video {
    padding-top: 45px;
    display: flex;
  }

  .voiceover {
    color: #efefef;
    display: inline-block;
    font-size: 18px;
    margin-right: 20px;
    margin-bottom: 20px;
    border: 2px solid #4e3883;
    border-radius: 20px;
    padding: 3px 30px;
    cursor: pointer;
    transition: all .4s ease;
  }
}

@media (max-width: 1340px){
  .video-player {
    padding-left: 20px;
    width: 930px;
  }

  iframe{
    height: 400px;
  }
}

@media (max-width: 752px){
  .video-player {
    margin: 0 20px;
    padding: 0;
    height: auto;
  }

  iframe{
    margin-top: 10px;
    height: 250px;
  }

  .text-video-player {
    color: #efefef;
    font-size: 28px;
    line-height: 50px;
  }

  .container.page-video {
    padding-top: 45px;
    display: flex;
  }

  .voiceover {
    color: #efefef;
    display: inline-block;
    font-size: 16px;
    margin-right: 10px;
    margin-bottom: 10px;
    padding: 3px 20px;
  }
}
</style>