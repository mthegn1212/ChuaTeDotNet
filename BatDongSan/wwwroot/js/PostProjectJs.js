let provinceData = {};
let districtData = {};
let wardData = {};

// Hàm tải danh sách Tỉnh/Thành phố
function loadTinhTp() {
fetch('/api/location/tinh_tp')
    .then(response => response.json())
    .then(data => {
        provinceData = data;
        const tinhTpSelect = document.getElementById('tinhThanh');
        tinhTpSelect.innerHTML = '<option value="" disabled selected>Chọn Tỉnh/Thành phố</option>';
        for (const key in data) {
            const option = document.createElement('option');
            option.value = data[key].name; // Gán name làm value
            option.textContent = data[key].name;
            tinhTpSelect.appendChild(option);
        }
    });
}

// Hàm tải danh sách Quận/Huyện
function loadQuanHuyen() {
    const tinhName = document.getElementById('tinhThanh').value;
    if (!tinhName) return;
    
    const tinhCode = Object.keys(provinceData).find(key => provinceData[key].name === tinhName);
    if (!tinhCode) return;
    
    fetch(`/api/location/quan_huyen?tinh_id=${tinhCode}`)
    .then(response => response.json())
    .then(data => {
        districtData = data;
        const quanHuyenSelect = document.getElementById('quanHuyen');
        quanHuyenSelect.innerHTML = '<option value="" disabled selected>Chọn Quận/Huyện</option>';
        for (const key in data) {
            const option = document.createElement('option');
            option.value = data[key].name; // Gán name làm value
            option.textContent = data[key].name;
            quanHuyenSelect.appendChild(option);
        }
    });
}

// Hàm tải danh sách Xã/Phường
function loadXaPhuong() {
    const quanName = document.getElementById('quanHuyen').value;
    if (!quanName) return;
    
    const quanCode = Object.keys(districtData).find(key => districtData[key].name === quanName);
    if (!quanCode) return;
    
    fetch(`/api/location/xa_phuong?quan_id=${quanCode}`)
    .then(response => response.json())
    .then(data => {
        wardData = data;
        const xaPhuongSelect = document.getElementById('xaPhuong');
        xaPhuongSelect.innerHTML = '<option value="" disabled selected>Chọn Xã/Phường</option>';
        for (const key in data) {
            const option = document.createElement('option');
            option.value = data[key].name; // Gán name làm value
            option.textContent = data[key].name;
            xaPhuongSelect.appendChild(option);
        }
    });
}

// Tải danh sách tỉnh/thành phố khi trang tải
window.onload = function () {
    loadTinhTp();
};

let editorInstance;

// Cấu hình CKEditor
ClassicEditor
    .create(document.querySelector('#Description'))
    .then(editor => {
        editorInstance = editor;
    })
    .catch(error => console.error(error));

function syncDescription() {
    if (editorInstance) {
        const rawContent = editorInstance.getData(); // Lấy nội dung từ CKEditor
        const cleanedContent = rawContent
        .replace(/<p>/g, '') // Xóa thẻ mở `<p>`
        .replace(/<\/p>/g, '') // Xóa thẻ đóng `</p>`
        .trim(); // Xóa khoảng trắng đầu và cuối
        const descriptionField = document.getElementById('Description');
        descriptionField.value = cleanedContent; // Gán nội dung đã làm sạch vào input ẩn
    }
}

// Hàm lấy địa chỉ đầy đủ
function getLocate() {
    const provinceId = document.getElementById('tinhThanh').value;
    const districtId = document.getElementById('quanHuyen').value;
    const wardId = document.getElementById('xaPhuong').value;
    const street = document.getElementById('diaChiCuThe').value;
    
    const provinceName = provinceData[provinceId]?.name || '';
    const districtName = districtData[districtId]?.name || '';
    const wardName = wardData[wardId]?.name || '';
    
    // Kết hợp các thành phần thành địa chỉ
    return [provinceName, districtName, wardName, street].filter(Boolean).join(", ");
}

// Hàm gán địa chỉ vào input ẩn
function setLocate() {
    document.getElementById('Locate').value = getLocate();
}

function handleFormSubmit() {

    if (editorInstance) {
        const descriptionField = document.getElementById('Description');
        descriptionField.value = editorInstance.getData();
    }
    // Gọi hàm để đặt giá trị địa chỉ
    setLocate();
    
    // Gọi hàm để đồng bộ dữ liệu CKEditor
    syncDescription();
    
    // Hiển thị thông báo (nếu cần)
    alert("Bạn đã đăng tin thành công!");
    
    // Trả về true để cho phép gửi form
    return true;
}
