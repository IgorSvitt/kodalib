<template>
  <div class="test-bg">
    <div class="container page-video">
      <div class="video-player">
        <div class="text-video-player">
          <span>Смотреть</span> «{{ link.title }}»
        </div>
        <div v-for="(voice, index) in voiceovers" :key="index" class="voiceover"
             :class="{active:(index===activeVoice)}" @click="setActiveIndex(index)">
          {{ voice.voiceover }}
        </div>

        <iframe :src="voiceovers[activeVoice].link" width="100%" height="720px"
                frameborder="0" allowfullscreen allow="autoplay *; fullscreen *"></iframe>
      </div>
    </div>
  </div>
</template>

<script>
import {computed, ref} from "vue";

export default {
  name: "VideoPlayer",
  props: {
    link: {
      type: Object
    }
  },
  setup(props) {
    const voiceovers = computed(() => props.link.linkVideo)
    const activeVoice = ref(0)

    function setActiveIndex(index) {
      activeVoice.value = index
    }

    return {
      voiceovers,
      activeVoice,
      setActiveIndex
    }
  }
}
</script>

<style scoped>
.video-player {
  padding-left: 20px;
  width: 1280px;
  height: auto;
}

.text-video-player {
  color: #efefef;
  font-size: 40px;
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