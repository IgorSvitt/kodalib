<template>
  <div class="container">
    <div class="comment">
      <div class="comment-title">
        Комментарии
      </div>
      <div class="errors" v-show="errorMessage.length !== 0">
        Пожалуйста исправьте указанные ошибки:
        <div class="error">{{ errorMessage }}</div>
      </div>
      <form>
        <div>
          <input type="text" class="name-com" placeholder="Введите ваше имя" v-model="comment.name">
        </div>
        <div>
          <textarea name="comment" id="comment" placeholder="Написать свой комментарий ..." class="text-com"
                    v-model="comment.message"></textarea>
        </div>
        <div class="rate">
          <div class="rate-title">
            <div class="rate-title">
              Оценить:
            </div>
            <div class="rate-numbers">
             <span v-for="number in 10" :key="number" class="number"
                   @click="comment.rate = number, activeRating(number)" :class="{active: activeRate === number}">
               {{ number }}
             </span>
            </div>
          </div>
          <button type="button" class="btn-com" @click="addComment">Опубликовать</button>
        </div>
      </form>
      <hr>
      <div class="comment-title">
        Количество комметриев: {{ comments.length }}
      </div>
      <div v-for="(com, index) in comments" :key="index" class="users-comments">
        <div class="name-user-com">
          {{ com.name }}

        </div>
        <div class="message-user-com">
          {{ com.message }}
        </div>
        <div class="rate-user-com">
          {{ com.rate }} / 10
        </div>
      </div>
    </div>
    <rating-comment :rate="rating" />
  </div>
</template>

<script>
import {ref} from "vue";
import RatingComment from "@/components/UI/Comment/RatingComment";

export default {
  name: "MyComment",
  components: { RatingComment},
  props: {
    rating: {
      type: Object
    }
  },
  setup() {
    const errorMessage = ref("")
    const activeRate = ref(0)
    const comment = ref({
      name: "",
      rate: 0,
      message: ""
    })
    const comments = ref([{
      name: "Игорь",
      message: "Сюжет скорее всего найдет отклик у многих. Тема школьного насилия актуальна для любой страны, в той или иной степени. Снято качественно, характеры героев цепляют. Все 8 серий лично я посмотрела залпом.\n" +
          "\n" +
          "Только описание в последнем абзаце не совсем коректно. Не на детях, ребенок там только 1. И ту девочку она не трогает и не обижает, даже наоборот. \n" +
          "Мстить она будет своим обидчикам, и больше всего матери девочки, которую играет Им Джи Ён. ",
      rate: 8
    }])

    function addComment() {
      const com = {
        name: comment.value.name,
        rate: comment.value.rate,
        message: comment.value.message
      }
      if (com.name.length < 2) {
        errorMessage.value = "Имя должно быть больше 2 символов"
      } else if (com.name.length > 20) {
        errorMessage.value = "Имя должно быть меньше 20 символов"
      } else if (com.message.length < 100) {
        errorMessage.value = "Отзыв должен быть больше 100 символов"
      } else if (com.message.length > 500) {
        errorMessage.value = "Отзыв должен быть меньше 500 символов"
      } else if (com.rate === 0) {
        errorMessage.value = "Нет оценки"
      } else {
        comments.value.push(com)
        comment.value.name = ""
        comment.value.rate = 0
        comment.value.message = ""
        errorMessage.value = ""
      }
    }

    function activeRating(number) {
      activeRate.value = number
    }

    return {
      comments,
      addComment,
      comment,
      activeRate,
      activeRating,
      errorMessage
    }
  }
}
</script>

<style scoped>

*, *::before, *::after {
  box-sizing: border-box;
}

.container {
  display: flex;
  justify-content: space-around;
}

.comment {
  color: #ffddcc;
  width: 50%;
}

.comment-title {
  margin: 45px 0 20px;
  color: #ffddcc;
  font-size: 30px;
  font-weight: 600;
}

input, textarea {
  outline: none;
  padding-left: 20px;
}

.name-com {
  width: 100%;
  height: 40px;
  border-radius: 20px;
  margin-bottom: 10px;
  color: #ffddcc;
  font-size: 16px;
  background: none;
  border: 3px solid #ffddcc;
}

.text-com {
  width: 100%;
  height: 100px;
  resize: none;
  color: #ffddcc;
  border: 3px solid #ffddcc;
  border-radius: 20px;
  background: none;
  font-size: 16px;
  padding-top: 5px;
}

.btn-com {
  border: none;
  border-radius: 20px;
  padding: 10px 20px;
  font-size: 16px;
  background-color: #503883;
  color: #efefef;
  font-weight: 600;
  border: 5px solid #503883;
}


.btn-com:hover {
  cursor: pointer;
  background-color: #1B132E;
  transition: all 0.3s ease;
  box-shadow: 0 0 20px #503883;
}

.rate {
  width: 100%;
  margin: 15px 0 45px;
  display: flex;
  justify-content: space-between;
}


hr {
  height: 2px;
  background: linear-gradient(90deg, rgba(255, 221, 204, 1) 0%, rgba(239, 239, 239, 1) 100%);
}

.rate-title {
  width: 70%;
  font-size: 20px;
}

.rate-numbers {
  display: flex;
  justify-content: space-between;
  width: 80%;
}

.number {
  margin-right: 10px;
  font-size: 20px;
  width: 30px;
  text-align: center;
  border-bottom: 5px solid rgba(0, 0, 0, 0);
}

.number.active {
  border-bottom: 2px solid #ffb996;
}

.number:hover {
  border-bottom: 2px solid #ffb996;
  cursor: pointer;
}

.users-comments {
  margin: 20px 0;
}

.errors {
  font-size: 20px;
  margin: 20px 0;
  color: #FEAAE3;
}

.error {
  margin-top: 10px;
  font-size: 24px;
}

.users-comments {
  background: #503883;
  padding: 20px;
  border-radius: 20px;
}

.name-user-com {
  font-size: 24px;
  font-weight: 500;
  color: #ffb996;
  margin-bottom: 10px;
}

.message-user-com {
  margin-bottom: 10px;
  font-size: 18px;
  word-break: break-all;
}

.rate-user-com {
  font-size: 26px;
  text-align: right;
}



</style>