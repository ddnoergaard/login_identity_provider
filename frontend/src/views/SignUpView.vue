<script setup>
import { auth } from '@/lib/firebase';
import { createUserWithEmailAndPassword } from 'firebase/auth';
import { computed, ref } from 'vue';
import { RouterLink } from 'vue-router';

const emailInput = ref(null)
const passwordInput = ref(null)
const passwordValidateInput = ref(null)
const missingEmail = ref(false)
const passwordMatch = computed(() => (passwordInput.value != '' && passwordInput.value === passwordValidateInput.value))

async function SignUp() {
    const result = ref(null);

    if (!passwordMatch.value) {
        console.log(passwordMatch)
        return
    }

    try {
        result.value = await createUserWithEmailAndPassword(auth, emailInput.value, passwordInput.value);
        console.log('signup succesful: ', result)
    }
    catch (error) {
        console.log(error)
    }





}


</script>

<template>
    <div id="container">
        <div id="login-card">
            <div id="lc-text">
                <h1>Sign up</h1>
                <p>Lets get you started!</p>
            </div>
            <div id="input-container">
                <div class="input-divider">
                    <input :class="{ 'missing-input': missingEmail }" type="email" name="emailI"
                        placeholder="john@doe.com" v-model="emailInput">
                </div>
                <div class="input-divider">
                    <input :class="{ 'missing-input': !passwordMatch }" type="password" name="passwordI"
                        placeholder="Password" v-model="passwordInput">
                </div>
                <div class="input-divider">
                    <input :class="{ 'missing-input': !passwordMatch }" type="password" name="passwordI"
                        placeholder="Validate password" v-model="passwordValidateInput">
                </div>
            </div>
            <div id="cta-container">
                <button @click="SignUp">Sign up</button>
                <RouterLink :to="{ name: 'login' }">Already a member?</RouterLink>
            </div>
        </div>
    </div>
</template>

<style scoped>
#container {
    width: 100dvw;
    height: 100dvh;
    display: flex;
    place-items: center;
    justify-content: center;
}

.error-msg {
    color: red;
}

#login-card {
    display: flex;
    min-width: 20dvw;
    min-height: 40dvh;
    flex-direction: column;
    text-align: center;
    gap: 1rem;
    padding: 2rem;
    background-color: var(--bg);
    border-radius: 1rem;
    justify-content: space-evenly;
}

#lc-text {
    display: flex;
    flex-direction: column;
    gap: 0.5rem;
}

#input-container {
    display: flex;
    flex-direction: column;
    gap: 2rem;
    place-items: center;
}

input {
    height: 1.5rem;
    width: 100%;
    padding: 1rem;
    border: 1px solid transparent;
    border-radius: 0.5rem;
    outline: none;
    color: var(--bg);
}

input:focus {
    border-color: white;
}

.missing-input {
    border-width: 2px;
    border-color: red;
}

button {
    width: fit-content;
    place-self: center;
    padding: 0.5rem 1rem;
    color: var(--text);
    background-color: transparent;
    border: 1px solid var(--light-b);
    transition: .3s;
    cursor: pointer;
}

button:hover {
    background-color: var(--light-b);
    color: var(--bg);
}

.input-divider {
    width: 100%;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: start;
}

.input-divider>input {
    place-self: center;
}

#cta-container {
    display: flex;
    justify-content: space-evenly;
    align-items: center;
}

@media (width < 1250px) {
    #login-card {
        width: 100dvw;
        height: 100dvh;
        padding: 0;
        border-radius: 0;
    }
}
</style>